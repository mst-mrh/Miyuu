#if !SERVER
using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Xna.Framework;
#endif
// ReSharper disable InconsistentNaming

namespace Miyuu.Cns
{
	public static class ClaymanInputCaputure
	{
#if !SERVER
		private static bool _initialized;

		private static IntPtr _windowHandle;
		private static IntPtr _hImc;

		private static IntPtr _prevWndProc;
		private static WndProc _hookProcDelegate;

		private static bool _hasListOld;
		private static bool _hasList;

		internal static bool Enabled { get; private set; }

		public static void OpenImm()
		{
			Enabled = true;
			IMM.ImmAssociateContext(_windowHandle, _hImc);
		}

		public static void CloseImm()
		{
			Enabled = false;
			IMM.ImmAssociateContext(_windowHandle, IntPtr.Zero);
		}

		public static bool GcsTest(ref string originText)
		{
			_hasListOld = _hasList;
			try
			{
				_hasList = IMM.ImmGetCompositionString(_hImc, 8, null, 0) > 0;
			}
			catch
			{
				// ignored
			}

			return Terraria.Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back) && (_hasListOld || _hasList);
		}

		public static void Initialize(GameWindow window)
		{
			if (_initialized)
				throw new InvalidOperationException("InputCaputure.Initialize can only be called once!");

			_hookProcDelegate = HookProc;
			_prevWndProc = (IntPtr)SetWindowLong(window.Handle, GWL_WNDPROC, (int)Marshal.GetFunctionPointerForDelegate(_hookProcDelegate));
			_hImc = IMM.ImmGetContext(window.Handle);
			_initialized = true;

			_windowHandle = window.Handle;
		}

		private static IntPtr HookProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			switch (msg)
			{
				case IMM.WindowMessage.InputLanguageChange:
					{
						if (Enabled)
						{
							IMM.ImmAssociateContext(_windowHandle, _hImc);
						}
						return (IntPtr)1;
					}
				case IMM.WindowMessage.ImeSetContext:
					{
						if (wParam.ToInt32() == 1)
						{
							var imeContext = IMM.ImmGetContext(hWnd);
							IMM.ImmAssociateContext(_windowHandle, imeContext);
						}
						return (IntPtr)1;
					}
				default:
					return CallWindowProc(_prevWndProc, hWnd, msg, wParam, lParam);
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		private const int GWL_WNDPROC = -4;
	}

	public static class IMM
	{
		[DllImport("imm32.dll", SetLastError = true)]
		internal static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr ImmGetContext(IntPtr hWnd);

		[DllImport("imm32.dll", CharSet = CharSet.Unicode)]
		internal static extern uint ImmGetCompositionString(IntPtr hIMC, ushort deIndex, StringBuilder candidateList, ushort dwBufLen);

		public static class WindowMessage
		{
			public const int Char = 0x0102;
			public const int ImeStartCompostition = 0x010D;
			public const int ImeEndComposition = 0x010E;
			public const int ImeComposition = 0x010F;
			public const int ImeKeyLast = 0x010F;
			public const int ImeSetContext = 0x0281;
			public const int ImeNotify = 0x0282;
			public const int ImeControl = 0x0283;
			public const int ImeCompositionFull = 0x0284;
			public const int ImeSelect = 0x0285;
			public const int ImeChar = 0x286;
			public const int ImeRequest = 0x0288;
			public const int ImeKeyDown = 0x0290;
			public const int ImeKeyUp = 0x0291;
			public const int InputLanguageChange = 0x0051;
		}
#endif
	}
}
