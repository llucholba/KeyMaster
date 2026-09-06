using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyMaster.Controls
{
    public partial class HotkeyCaptureControl : UserControl
    {
        private readonly Button _button;

        private bool _capturing;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private readonly HashSet<Keys> _pressedKeys = new HashSet<Keys>();

        private readonly List<Keys> _hotkeyKeys = new List<Keys>();

        public IReadOnlyList<Keys> SelectedKeys
        {
            get { return _hotkeyKeys.AsReadOnly(); }
        }

        public event EventHandler HotkeyCaptured;

        public HotkeyCaptureControl()
        {
            Height = 35;
            Width = 350;

            _button = new Button
            {
                Text = "Presionar combinación...",
                Dock = DockStyle.Fill,
                BackColor = Color.LightGoldenrodYellow,
                TabStop = true
            };

            _button.Click += Button_Click;
            _button.PreviewKeyDown += Button_PreviewKeyDown;
            _button.KeyDown += Button_KeyDown;
            _button.KeyUp += Button_KeyUp;

            Controls.Add(_button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            BeginCapture();
        }

        private void BeginCapture()
        {
            if (_capturing)
                return;

            _capturing = true;

            _pressedKeys.Clear();
            _hotkeyKeys.Clear();

            _button.Text = "Presioná la combinación...";
            _button.BackColor = Color.LightGray;

            _button.Focus();
        }

        private void Button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!_capturing)
                return;

            e.IsInputKey = true;
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_capturing)
                return;

            Keys key = GetRealKey(e.KeyCode);

            if (!_pressedKeys.Contains(key))
            {
                _pressedKeys.Add(key);

                if (!_hotkeyKeys.Contains(key))
                    _hotkeyKeys.Add(key);
            }

            UpdateDisplay();

            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (!_capturing)
                return;

            Keys key = GetRealKey(e.KeyCode);

            _pressedKeys.Remove(key);

            // Cuando se soltaron todas las teclas,
            // damos por terminada la combinación.
            if (_pressedKeys.Count == 0 &&
                _hotkeyKeys.Count > 0)
            {
                _capturing = false;

                _button.BackColor = Color.LightGoldenrodYellow;

                HotkeyCaptured?.Invoke(
                    this,
                    EventArgs.Empty);
            }

            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private Keys GetRealKey(Keys key)
        {
            switch (key)
            {
                case Keys.ShiftKey:
                    if ((GetAsyncKeyState((int)Keys.RShiftKey) & 0x8000) != 0)
                        return Keys.RShiftKey;

                    return Keys.LShiftKey;

                case Keys.ControlKey:
                    if ((GetAsyncKeyState((int)Keys.RControlKey) & 0x8000) != 0)
                        return Keys.RControlKey;

                    return Keys.LControlKey;

                case Keys.Menu:
                    if ((GetAsyncKeyState((int)Keys.RMenu) & 0x8000) != 0)
                        return Keys.RMenu;

                    return Keys.LMenu;

                default:
                    return key;
            }
        }

        private void UpdateDisplay()
        {
            if (_hotkeyKeys.Count == 0)
            {
                _button.Text = "Presioná la combinación...";

                return;
            }

            _button.Text = string.Join(
                " + ",
                _hotkeyKeys.Select(GetDisplayName));
        }

        private string GetDisplayName(Keys key)
        {
            switch (key)
            {
                case Keys.LShiftKey:
                    return "Shift Izq";
                case Keys.RShiftKey:
                    return "Shift Der";

                case Keys.LControlKey:
                    return "Ctrl Izq";
                case Keys.RControlKey:
                    return "Ctrl Der";

                case Keys.LMenu:
                    return "Alt Izq";
                case Keys.RMenu:
                    return "Alt Der";

                case Keys.Enter:
                    return "Enter";

                case Keys.Tab:
                    return "Tab";

                case Keys.Space:
                    return "Espacio";

                case Keys.Escape:
                    return "Esc";

                case Keys.Back:
                    return "Retroceso";

                case Keys.Insert:
                    return "Insert";
                case Keys.Home:
                    return "Inicio";
                case Keys.Delete:
                    return "Supr";
                case Keys.End:
                    return "Fin";
                case Keys.PageUp:
                    return "Page Up";
                case Keys.PageDown:
                    return "Page Down";

                case Keys.Up:
                    return "Arriba";
                case Keys.Down:
                    return "Abajo";
                case Keys.Left:
                    return "Izq";
                case Keys.Right:
                    return "Der";

                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.D0:
                    return "0";

                case Keys.NumPad1:
                    return "Num 1";
                case Keys.NumPad2:
                    return "Num 2";
                case Keys.NumPad3:
                    return "Num 3";
                case Keys.NumPad4:
                    return "Num 4";
                case Keys.NumPad5:
                    return "Num 5";
                case Keys.NumPad6:
                    return "Num 6";
                case Keys.NumPad7:
                    return "Num 7";
                case Keys.NumPad8:
                    return "Num 8";
                case Keys.NumPad9:
                    return "Num 9";
                case Keys.NumPad0:
                    return "Num 0";
                case Keys.Add:
                    return "Num +";
                case Keys.Subtract:
                    return "Num -";
                case Keys.Multiply:
                    return "Num *";
                case Keys.Divide:
                    return "Num /";
                case Keys.NumLock:
                    return "Bloq Num";
                case Keys.Decimal:
                    return "Num .";

                case Keys.Capital:
                    return "Bloq Mayús";

                case Keys.Oemtilde:
                    return "Ñ";

                case Keys.Oemcomma:
                    return ",";
                case Keys.OemPeriod:
                    return ".";
                case Keys.Oemplus:
                    return "(+)";
                case Keys.OemMinus:
                    return "(-)";

                case Keys.PrintScreen:
                    return "Impr Pant";
                case Keys.Scroll:
                    return "Bloq Despl";
                case Keys.Pause:
                    return "Pausa";

                default:
                    return key.ToString();
            }
        }

        public void Clear()
        {
            _capturing = false;

            _pressedKeys.Clear();
            _hotkeyKeys.Clear();

            _button.BackColor = Color.LightGoldenrodYellow;

            _button.Text = "Presionar combinación...";
        }
    }
}
