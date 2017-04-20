#if !SERVER
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.OS;
using Terraria;
using Terraria.Localization;
using Color = Microsoft.Xna.Framework.Color;
#endif

namespace Miyuu.Cns
{
	public static class CnsMain
	{
#if !SERVER
		private static FontFamily _cnFont; // 内存分配

		public static void PostInitialize()
		{
			LanguageManager.Instance.SetLanguage(GameCulture.Chinese);
		}

		public static void LoadFonts()
		{
			const string fontFileName = "Font.tt*";

			var collection = new PrivateFontCollection();
			var files = Directory.GetFiles(Directory.GetCurrentDirectory(), fontFileName);
			for (var index = 0; index < files.Length; index++)
			{
				collection.AddFontFile(files[index]);
			}
			if (collection.Families.Length != 1)
			{
				MessageBox.Show("加载字体失败; 请确保游戏目录下有且只有一个 Font.ttf 或 Font.ttc 字体文件!", "Terraria");
				Environment.Exit(1);
			}

			var fontName = collection.Families.First().Name;
			var font = new FontFamily(fontName, collection);

			_cnFont = font;

#if TML
			if (Main.XfontCombatText == null)
			{
				Main.XfontCombatText = new SpriteFontCn[2];
			}

			Main.XfontMouseText = new SpriteFontCn(new Font(_cnFont, 17.55F, GraphicsUnit.Pixel));
			Main.XfontItemStack = new SpriteFontCn(new Font(_cnFont, 16.2F, GraphicsUnit.Pixel));
			Main.XfontDeathText = new SpriteFontCn(new Font(_cnFont, 33.75F, GraphicsUnit.Pixel));
			Main.XfontCombatText[1] = new SpriteFontCn(new Font(_cnFont, 20.25F, GraphicsUnit.Pixel));
			Main.XfontCombatText[0] = new SpriteFontCn(new Font(_cnFont, 17.55F, GraphicsUnit.Pixel));
#else
			if (Main.fontCombatText == null)
			{
				Main.fontCombatText = new SpriteFontCn[2];
			}

			Main.fontMouseText = new SpriteFontCn(new Font(_cnFont, 17.55F, GraphicsUnit.Pixel));
			Main.fontItemStack = new SpriteFontCn(new Font(_cnFont, 16.2F, GraphicsUnit.Pixel));
			Main.fontDeathText = new SpriteFontCn(new Font(_cnFont, 33.75F, GraphicsUnit.Pixel));
			Main.fontCombatText[1] = new SpriteFontCn(new Font(_cnFont, 20.25F, GraphicsUnit.Pixel));
			Main.fontCombatText[0] = new SpriteFontCn(new Font(_cnFont, 17.55F, GraphicsUnit.Pixel));
#endif
		}

		public static void DrawGroupInfo(Color color)
		{
			const string groupInfo = "抗药又坚硬汉化组";

			for (var i = 0; i < 5; i++)
			{
				var c6 = Color.Black;
				if (i == 4)
				{
					c6 = color;
					c6.R = (byte)((0 + c6.R) / 2);
					c6.G = (byte)((255 + c6.R) / 2);
					c6.B = (byte)((0 + c6.R) / 2);
				}
				c6.A = (byte)(c6.A * 0.3f);
				var num107 = 0;
				var num108 = 0;
				if (i == 0)
					num107 = -2;
				if (i == 1)
					num107 = 2;
				if (i == 2)
					num108 = -2;
				if (i == 3)
					num108 = 2;
#if TML
				var o3 = Main.XfontMouseText.MeasureString(groupInfo);
#else
				var o3 = Main.fontMouseText.MeasureString(groupInfo);
#endif
				o3.X *= 0.5f;
				o3.Y *= 0.5f;
#if !TML
				Main.spriteBatch.DrawString(Main.fontMouseText, groupInfo,
					new Vector2(o3.X + num107 + 10f, Main.screenHeight - o3.Y + num108 - 22f), c6, 0f, o3, 1f, SpriteEffects.None, 0f);
#else
				Main.spriteBatch.DrawString(Main.XfontMouseText, groupInfo,
					new Vector2(Main.screenWidth - o3.X + num108 - 10f, Main.screenHeight - o3.Y + num107 - 23f), c6, 0f, o3, 1f, SpriteEffects.None, 0f);
#endif
				Main.ignoreErrors = false;
			}
		}

		private static bool _hasListOld, _hasList;

		public static bool GetInputText()
		{
			_hasListOld = _hasList;
			try
			{
				_hasList = Platform.Current.Ime.IsCandidateListVisible;
			}
			catch
			{
				// ignored
			}

			return Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back) && (_hasListOld || _hasList);
		}
#endif
	}
}
