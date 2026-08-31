using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KeyMaster.Models;

namespace KeyMaster.Core
{
    public class KeyboardHook : IDisposable
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private const uint LLKHF_EXTENDED = 0x01;
        private const uint LLKHF_INJECTED = 0x10;
        private const uint LLKHF_ALTDOWN = 0x20;
        private const int WH_KEYBOARD_LL = 13;

        private readonly LowLevelKeyboardProc _proc;
        private IntPtr _hookId = IntPtr.Zero;

        public bool SuppressKey { get; set; }

        public event EventHandler<KeyEventArgs> KeyDown;
        public event EventHandler<KeyEventArgs> KeyUp;

        public event Func<Keys, bool> ShouldSuppressKey;

        public event Action<KeyboardEvent> KeyCaptured;

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(
        uint uCode,
        uint uMapType);
        private const uint MAPVK_VK_TO_VSC = 0;

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

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int message = wParam.ToInt32();

                KBDLLHOOKSTRUCT keyboardData = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

                Keys key = GetRealKey(keyboardData);

                bool isKeyDown =
                    message == WM_KEYDOWN ||
                    message == WM_SYSKEYDOWN;

                bool isKeyUp =
                    message == WM_KEYUP ||
                    message == WM_SYSKEYUP;

                bool isInjected =
                    (keyboardData.flags & LLKHF_INJECTED) != 0;

                if (isKeyDown)
                {
                    KeyDown?.Invoke(
                        this,
                        new KeyEventArgs(key));
                }
                else if (isKeyUp)
                {
                    KeyUp?.Invoke(
                        this,
                        new KeyEventArgs(key));
                }

                if (isKeyDown || isKeyUp)
                {
                    KeyCaptured?.Invoke(
                        new KeyboardEvent(
                            key,
                            (int)keyboardData.scanCode,
                            (int)keyboardData.flags,
                            isKeyDown,
                            isInjected));
                }

                if (isKeyDown)
                {
                    if (ShouldSuppressKey != null &&
                        ShouldSuppressKey(key))
                    {
                        return (IntPtr)1;
                    }
                }
            }

            return CallNextHookEx(
                _hookId,
                nCode,
                wParam,
                lParam);
        }

        private Keys GetRealKey(KBDLLHOOKSTRUCT data)
        {
            switch (data.vkCode)
            {
                case 0x10: // SHIFT

                    if (data.scanCode == 0x36)
                        return Keys.RShiftKey;

                    return Keys.LShiftKey;

                case 0x11: // CTRL

                    if ((data.flags & LLKHF_EXTENDED) != 0)
                        return Keys.RControlKey;

                    return Keys.LControlKey;

                case 0x12: // ALT

                    if ((data.flags & LLKHF_EXTENDED) != 0)
                        return Keys.RMenu;

                    return Keys.LMenu;

                default:
                    return (Keys)data.vkCode;
            }
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