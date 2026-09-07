using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyMaster.Core
{
    public static class KeySender
    {
        private const uint INPUT_KEYBOARD = 1;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        private const uint KEYEVENTF_UNICODE = 0x0004;

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(
            uint nInputs,
            INPUT[] pInputs,
            int cbSize);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static bool SendKey(Keys key)
        {
            ushort virtualKey = (ushort)key;

            INPUT[] inputs =
            {
                new INPUT
                {
                    type = INPUT_KEYBOARD,

                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = virtualKey,
                            wScan = 0,
                            dwFlags = 0,
                            time = 0,
                            dwExtraInfo = UIntPtr.Zero
                        }
                    }
                },

                new INPUT
                {
                    type = INPUT_KEYBOARD,

                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = virtualKey,
                            wScan = 0,
                            dwFlags = KEYEVENTF_KEYUP,
                            time = 0,
                            dwExtraInfo = UIntPtr.Zero
                        }
                    }
                }
            };

            uint result = SendInput(
                (uint)inputs.Length,
                inputs,
                Marshal.SizeOf(typeof(INPUT)));

            if (result != inputs.Length)
            {
                int error = Marshal.GetLastWin32Error();

                throw new System.ComponentModel.Win32Exception(error);
            }

            return true;
        }

        // Método teclado unicode (no usa el portapapeles)
        public static bool SendText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            foreach (char character in text)
            {
                INPUT[] inputs =
                {
                    new INPUT
                    {
                        type = INPUT_KEYBOARD,

                        U = new InputUnion
                        {
                            ki = new KEYBDINPUT
                            {
                                wVk = 0,
                                wScan = character,
                                dwFlags = KEYEVENTF_UNICODE,
                                time = 0,
                                dwExtraInfo = UIntPtr.Zero
                            }
                        }
                    },

                    new INPUT
                    {
                        type = INPUT_KEYBOARD,

                        U = new InputUnion
                        {
                            ki = new KEYBDINPUT
                            {
                                wVk = 0,
                                wScan = character,
                                dwFlags =
                                    KEYEVENTF_UNICODE |
                                    KEYEVENTF_KEYUP,
                                time = 0,
                                dwExtraInfo = UIntPtr.Zero
                            }
                        }
                    }
                };

                uint result = SendInput(
                    (uint)inputs.Length,
                    inputs,
                    Marshal.SizeOf(typeof(INPUT)));

                if (result != inputs.Length)
                {
                    int error = Marshal.GetLastWin32Error();

                    throw new System.ComponentModel.Win32Exception(error);
                }
            }

            return true;
        }

        // Método portapapeles (lo inserta temporalmente y luego restaura el que teníamos antes, para no perder nada)
        public static bool SendTextViaClipboard(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            IDataObject oldClipboard = null;

            try
            {
                // Crear una copia independiente del portapapeles actual
                oldClipboard = CloneClipboardData();

                // Colocar temporalmente nuestro texto
                Clipboard.SetText(text);

                // Darle tiempo a Windows para actualizarlo
                System.Threading.Thread.Sleep(50);

                // Pegar
                SendCtrlV();

                // Darle tiempo a la aplicación destino
                System.Threading.Thread.Sleep(150);

                return true;
            }
            finally
            {
                // Restaurar el portapapeles completo
                try
                {
                    if (oldClipboard != null)
                    {
                        Clipboard.SetDataObject(
                            oldClipboard,
                            true);
                    }
                    else
                    {
                        Clipboard.Clear();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "No se pudo restaurar el portapapeles: " +
                        ex.Message);
                }
            }
        }
        private static IDataObject CloneClipboardData()
        {
            IDataObject source = Clipboard.GetDataObject();

            if (source == null)
                return null;

            DataObject clone = new DataObject();

            string[] formats = source.GetFormats(false);

            foreach (string format in formats)
            {
                try
                {
                    object data = source.GetData(format, false);

                    if (data != null)
                    {
                        clone.SetData(format, data);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "No se pudo copiar el formato " +
                        format +
                        ": " +
                        ex.Message);
                }
            }

            return clone;
        }

        public static void WaitForHotkeyRelease(System.Collections.Generic.List<Keys> hotkeyKeys)
        {
            while (true)
            {
                bool anyPressed = false;

                foreach (Keys key in hotkeyKeys)
                {
                    short state = GetAsyncKeyState((int)key);

                    if ((state & 0x8000) != 0)
                    {
                        anyPressed = true;
                        break;
                    }
                }

                if (!anyPressed)
                    break;

                System.Threading.Thread.Sleep(10);
            }
        }
        private static bool SendCtrlV()
        {
            const ushort VK_CONTROL = 0x11;
            const ushort VK_V = 0x56;

            INPUT[] inputs =
            {
                // Ctrl DOWN
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = VK_CONTROL,
                            wScan = 0,
                            dwFlags = 0,
                            time = 0,
                            dwExtraInfo = UIntPtr.Zero
                        }
                    }
                },

                // V DOWN
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = VK_V,
                            wScan = 0,
                            dwFlags = 0,
                            time = 0,
                            dwExtraInfo = UIntPtr.Zero
                        }
                    }
                },

                // V UP
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = VK_V,
                            wScan = 0,
                            dwFlags = KEYEVENTF_KEYUP,
                            time = 0,
                            dwExtraInfo = UIntPtr.Zero
                        }
                    }
                },

                // Ctrl UP
                new INPUT
                {
                    type = INPUT_KEYBOARD,
                    U = new InputUnion
                    {
                        ki = new KEYBDINPUT
                        {
                            wVk = VK_CONTROL,
                            wScan = 0,
                            dwFlags = KEYEVENTF_KEYUP,
                            time = 0,
                            dwExtraInfo = UIntPtr.Zero
                        }
                    }
                }
            };

            uint result = SendInput(
                (uint)inputs.Length,
                inputs,
                Marshal.SizeOf(typeof(INPUT)));

            if (result != inputs.Length)
            {
                int error = Marshal.GetLastWin32Error();

                throw new System.ComponentModel.Win32Exception(error);
            }

            return true;
        }
    }
}