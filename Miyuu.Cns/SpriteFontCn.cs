#if !SERVER
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Color = Microsoft.Xna.Framework.Color;
using Terraria;
#endif

namespace Miyuu.Cns
{
	public class SpriteFontCn
	{
#if !SERVER
		private static object Locker = new object();

		private Dictionary<char, CharTile> _charTiles = new Dictionary<char, CharTile>();

		private Graphics _tempGr;

		private Bitmap _tempBm;

		private Graphics _graphics;

		private Bitmap _bitMap;

		public Font Font => font;

		private Font font;

		private SizeF _size;

		public int LineSpacing => 21;

		public int Spacing => 0;

		public SpriteFontCn(Font font)
		{
			this.font = font;

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

		public string MeasureString_(string str, float maxWidth)
		{
			var array = str.ToCharArray();
			var vector = new Vector2(1f, 1f);
			var vector2 = new Vector2(maxWidth <= 0f ? 3.40282347E+38f : maxWidth, 3.40282347E+38f);
			var vector3 = default(Vector2);
			var vector4 = default(Vector2);
			var text = "";
			var i = 0;
			var num = array.Length;
			while (i < num)
			{
				var c = array[i];
				if (c == '\n')
				{
					text += '\n';
					vector3 = new Vector2(0f, vector4.Y);
				}
				else if (c != '\r')
				{
					if (!_charTiles.ContainsKey(c))
					{
						AddTex(c);
					}
					var charTile = _charTiles[c];
					if (vector3.X + charTile.Rectangle.Width * vector.X > vector2.X)
					{
						if (charTile.Rectangle.Width * vector.X > vector2.X)
						{
							goto IL_244;
						}
						text += '\n';
						vector3 = new Vector2(0f, vector4.Y);
					}
					if (vector3.Y + charTile.Rectangle.Height * vector.Y > vector4.Y)
					{
						if (vector3.Y + charTile.Rectangle.Height * vector.Y > vector2.Y)
						{
							break;
						}
						vector4.Y = vector3.Y + charTile.Rectangle.Height * vector.Y;
					}
					text += c;
					vector3.X += charTile.Rectangle.Width * vector.X;
					if (vector3.X > vector4.X)
					{
						vector4.X = vector3.X;
					}
				}
				IL_244:
				i++;
				continue;
			}
			return text;
		}

		public Vector2 MeasureString(string str)
		{
			return MeasureString(str.ToCharArray(), 3.40282347E+38f);
		}

		public Vector2 MeasureString(char[] chars)
		{
			return MeasureString(chars, 3.40282347E+38f);
		}

		public Vector2 MeasureString(char[] chars, float maxWidth)
		{
			return Draw(null, chars, Vector2.Zero, new Vector2(maxWidth, 3.40282347E+38f), new Vector2(1f, 1f), Color.White);
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
