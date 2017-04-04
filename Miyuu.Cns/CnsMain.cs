#if !SERVER
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Color = Microsoft.Xna.Framework.Color;
#endif

namespace Miyuu.Cns
{
	public class CnsMain
	{
#if !SERVER
		private readonly Game _instance;

		private FontFamily _cnFont; // 内存分配

		private IntPtr _gXaudioDll;

		private IntPtr _pXAudio2;

		private static bool _userInput;

		public CnsMain(Game game)
		{
			_instance = game;

			try
			{
				InitializeXAudio();
				_instance.Exiting += OnExiting;
			}
			catch
			{
				// ignored
			}
		}

		private void OnExiting(object sender, EventArgs eventArgs)
		{
			if (_pXAudio2 != IntPtr.Zero)
			{
				// release
			}

			if (_gXaudioDll != IntPtr.Zero)
			{
				FreeLibrary(_gXaudioDll);
				_gXaudioDll = IntPtr.Zero;
			}
		}

		private unsafe void InitializeXAudio()
		{
			_gXaudioDll = LoadLibraryEx("XAudio2_6.DLL", IntPtr.Zero, LoadLibrarySearchSystem32);

			var xAudio2Out = IntPtr.Zero;
			XAudio2Create_(&xAudio2Out, 0, DefaultProcessor);
			_pXAudio2 = xAudio2Out;
		}

		public void Initialize()
		{
			ClaymanInputCaputure.Initialize(_instance.Window);
		}

		public void PostInitialize()
		{
			Lang.lang = 2;
			Lang.setLang();
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

		public static void Update()
		{
			_userInput = ClaymanInputCaputure.ForceEnable || Main.drawingPlayerChat || Main.editSign || Main.editChest || Main.gameMenu && Main.menuMode == 888;
			if (_userInput && !Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
			{
				if (!ClaymanInputCaputure.Enabled)
					ClaymanInputCaputure.OpenImm();
			}
			else if (ClaymanInputCaputure.Enabled)
			{
				ClaymanInputCaputure.CloseImm();
			}
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr LoadLibraryEx(string dllToLoad, IntPtr hFile, uint flags);

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool FreeLibrary(IntPtr hModule);

		[DllImport("xaudio2_8.dll", EntryPoint = "XAudio2Create", CallingConvention = CallingConvention.StdCall)]
		private static extern unsafe int XAudio2Create_(void* arg0, int arg1, int arg2);

		private const uint LoadLibrarySearchSystem32 = 0x00000800;

		private const int DefaultProcessor = 0x00000001;
#endif
			}
}
