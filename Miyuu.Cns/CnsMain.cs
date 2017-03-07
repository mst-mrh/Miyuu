using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Color = Microsoft.Xna.Framework.Color;

namespace Miyuu.Cns
{
	public class CnsMain
	{
		public Game Current { get; }

		internal FontFamily CnFont; // 内存分配

		public CnsMain(Game game)
		{
			Current = game;
		}

		public void LoadFonts()
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

			CnFont = font;

			if (Main.fontCombatText == null)
			{
				Main.fontCombatText = new SpriteFontCn[2];
			}

			Main.fontMouseText = new SpriteFontCn(new Font(CnFont, 17.55F, GraphicsUnit.Pixel));
			Main.fontItemStack = new SpriteFontCn(new Font(CnFont, 16.2F, GraphicsUnit.Pixel));
			Main.fontDeathText = new SpriteFontCn(new Font(CnFont, 33.75F, GraphicsUnit.Pixel));
			Main.fontCombatText[1] = new SpriteFontCn(new Font(CnFont, 20.25F, GraphicsUnit.Pixel));
			Main.fontCombatText[0] = new SpriteFontCn(new Font(CnFont, 17.55F, GraphicsUnit.Pixel));
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
				var o3 = Main.fontMouseText.MeasureString(groupInfo);
				o3.X *= 0.5f;
				o3.Y *= 0.5f;
#if !TML
				Main.spriteBatch.DrawString(Main.fontMouseText, groupInfo,
					new Vector2(o3.X + num107 + 10f, Main.screenHeight - o3.Y + num108 - 22f), c6, 0f, o3, 1f, SpriteEffects.None, 0f);
#else
				Main.spriteBatch.DrawString(Main.fontMouseText, groupInfo,
					new Vector2(Main.screenWidth - o3.X + num108 - 10f, Main.screenHeight - o3.Y + num107 - 23f), c6, 0f, o3, 1f, SpriteEffects.None, 0f);
#endif
			}
		}

	}
}
