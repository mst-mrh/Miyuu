#if !SERVER
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using ReLogic.Text;
using Color = Microsoft.Xna.Framework.Color;
using Terraria;
#endif

namespace Miyuu.Cns
{
	public class SpriteFontCn : IFontMetrics
	{
#if !SERVER
		private static readonly object Locker = new object();

		private Dictionary<char, CharTile> _charTiles = new Dictionary<char, CharTile>();

		private Graphics _tempGr;

		private Bitmap _tempBm;

		private Graphics _graphics;

		private Bitmap _bitMap;

		public Font Font { get; }

		private SizeF _size;

		public int LineSpacing => 21;

		public float CharacterSpacing => 0;

		public int Spacing => 0;

		public SpriteFontCn(Font font)
		{
			Font = font;

			_tempBm = new Bitmap(1, 1);
			_tempGr = Graphics.FromImage(_tempBm);
		}

		protected void AddTex(char character)
		{
			lock (Locker)
			{
				if (_charTiles.ContainsKey(character))
				{
					return;
				}

				var text = character.ToString();

				_size = _tempGr.MeasureString(text, Font, PointF.Empty, StringFormat.GenericTypographic);

				if (_size.Width <= 0f)
				{
					_size.Width = _size.Height / 2f;
				}

				if (_bitMap == null || _bitMap.Width != (int)Math.Ceiling(_size.Width) || _bitMap.Height != (int)Math.Ceiling(_size.Height))
				{
					_bitMap = new Bitmap((int)Math.Ceiling(_size.Width), (int)Math.Ceiling(_size.Height), PixelFormat.Format32bppArgb);
					_graphics = Graphics.FromImage(_bitMap);
					_graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				}
				else
				{
					_graphics.Clear(System.Drawing.Color.Empty);
				}

				_graphics.DrawString(text, Font, Brushes.White, 0f, 0f, StringFormat.GenericTypographic);

				_charTiles.Add(character, new CharTile(ToTexture2D(_bitMap), new Microsoft.Xna.Framework.Rectangle(0, 0, _bitMap.Width, _bitMap.Height)));
			}
		}

		public Vector2 Draw(SpriteBatch sb, string str, Vector2 position, Color color)
		{
			return Draw(sb, str.ToCharArray(), position, SpriteBatchCn.MaxBound, Vector2.One, color);
		}

		public Vector2 Draw(SpriteBatch sb, char[] chars, Vector2 position, Color color)
		{
			return Draw(sb, chars, position, SpriteBatchCn.MaxBound, Vector2.One, color);
		}

		public Vector2 Draw(SpriteBatch sb, string str, Vector2 position, Vector2 maxBound, Vector2 scale, Color color)
		{
			return Draw(sb, str.ToCharArray(), position, maxBound, scale, color);
		}

		public Vector2 Draw(SpriteBatch sb, char[] chars, Vector2 position, Vector2 maxBound, Vector2 scale, Color color)
		{
			maxBound = new Vector2(maxBound.X <= 0f ? 3.40282347E+38f : maxBound.X, maxBound.Y <= 0f ? 3.40282347E+38f : maxBound.Y);
			var value = default(Vector2);
			var result = default(Vector2);
			var i = 0;
			var num = chars.Length;
			while (i < num)
			{
				var c = chars[i];
				if (c == '\n')
				{
					value = new Vector2(0f, result.Y);
				}
				else if (c != '\r')
				{
					if (!_charTiles.ContainsKey(c))
					{
						AddTex(c);
					}
					var charTile = _charTiles[c];
					if (value.X + charTile.Rectangle.Width * scale.X > maxBound.X)
					{
						if (charTile.Rectangle.Width * scale.X > maxBound.X)
						{
							goto IL_256;
						}
						value = new Vector2(0f, result.Y);
					}
					if (value.Y + charTile.Rectangle.Height * scale.Y > result.Y)
					{
						if (value.Y + charTile.Rectangle.Height * scale.Y > maxBound.Y)
						{
							break;
						}
						result.Y = value.Y + charTile.Rectangle.Height * scale.Y;
					}
					if (sb != null)
					{
						sb.Draw(charTile.Texture, position + value, charTile.Rectangle, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
					}
					value.X += charTile.Rectangle.Width * scale.X;
					if (value.X > result.X)
					{
						result.X = value.X;
					}
				}
				IL_256:
				i++;
				continue;
			}
			return result;
		}

		public GlyphMetrics GetCharacterMetrics(char character)
		{
			return GlyphMetrics.FromKerningData(0f, MeasureString(new[] { character }).X, 0f);
		}

		public Vector2 MeasureString(string str)
		{
			return MeasureString(str.ToCharArray());
		}

		private Vector2 MeasureString(char[] chars, float maxWidth = 3.40282347E+38f)
		{
			return Draw(null, chars, Vector2.Zero, new Vector2(maxWidth, maxWidth), new Vector2(1f, 1f), Color.White);
		}

		public string CreateWrappedText(string text, float maxWidth)
		{
			return CreateWrappedText(text, maxWidth, Thread.CurrentThread.CurrentCulture);
		}

		public string CreateWrappedText(string text, float maxWidth, CultureInfo culture)
		{
			var wrappedTextBuilder = new WrappedTextBuilder(this, maxWidth, culture);
			wrappedTextBuilder.Append(text);
			return wrappedTextBuilder.ToString();
		}

		public static Texture2D ToTexture2D(Bitmap bitmap)
		{
			using (var memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Png);

				memoryStream.Seek(0L, SeekOrigin.Begin);

				var texture2D = Texture2D.FromStream(Main.instance.GraphicsDevice, memoryStream);

				var array = new Byte4[texture2D.Width * texture2D.Height];
				texture2D.GetData(array);
				for (var i = 0; i < array.Length; i++)
				{
					var vector = array[i].ToVector4();
					var num = vector.W / 255f;
					var num2 = (int)vector.W;
					var num3 = (int)(num * vector.X);
					var num4 = (int)(num * vector.Y);
					var num5 = (int)(num * vector.Z);
					array[i].PackedValue = (uint)((num2 << 24) + num3 + (num4 << 8) + (num5 << 16));
				}
				Main.instance.GraphicsDevice.Textures[0] = null;
				texture2D.SetData(array);
				return texture2D;
			}
		}
#endif
	}
}
