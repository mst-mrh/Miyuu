using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Terraria;

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
    }
}
