using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyMaster.Core
{
    public class KeyboardHook : IDisposable
    {
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private readonly LowLevelKeyboardProc _proc;
        private IntPtr _hookId = IntPtr.Zero;

        public bool SuppressKey { get; set; }

        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<KeyEventArgs> KeyUp;

        public event Func<Keys, bool> ShouldSuppressKey;

        public KeyboardHook()
        {
            _proc = HookCallback;
        }

        public void Start()
        {
            if (_hookId != IntPtr.Zero)
                return;

            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                _hookId = SetWindowsHookEx(
                    WH_KEYBOARD_LL,
                    _proc,
                    GetModuleHandle(module.ModuleName),
                    0);
            }

            if (_hookId == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception(
                    Marshal.GetLastWin32Error());
        }

        public void Stop()
        {
            if (_hookId == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(_hookId);
            _hookId = IntPtr.Zero;
        }

        private IntPtr HookCallback(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int message = wParam.ToInt32();

                KBDLLHOOKSTRUCT keyboardData =
                    Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

                Keys key = (Keys)keyboardData.vkCode;

                if (message == WM_KEYDOWN || message == WM_SYSKEYDOWN)
                {
                    KeyDown?.Invoke(
                        this,
                        new KeyEventArgs(key));

                    if (ShouldSuppressKey != null && ShouldSuppressKey(key))
                    {
                        return (IntPtr)1;
                    }
                }
                else if (message == WM_KEYUP || message == WM_SYSKEYUP)
                {
                    KeyUp?.Invoke(
                        this,
                        new KeyEventArgs(key));
                }
            }

            return CallNextHookEx(
                _hookId,
                nCode,
                wParam,
                lParam);
        }

        public void Dispose()
        {
            Stop();
        }

        #region Windows API

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport(
            "user32.dll",
            CharSet = CharSet.Auto,
            SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelKeyboardProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport(
            "user32.dll",
            CharSet = CharSet.Auto,
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(
            IntPtr hhk);

        [DllImport(
            "user32.dll",
            CharSet = CharSet.Auto,
            SetLastError = true)]
        private static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport(
            "kernel32.dll",
            CharSet = CharSet.Auto,
            SetLastError = true)]
        private static extern IntPtr GetModuleHandle(
            string lpModuleName);

        #endregion
    }
}