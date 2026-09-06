using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyMaster.Controls
{
    public class KeyCaptureControl : UserControl
    {
        private readonly Button _button;

        private Keys _selectedKey = Keys.None;
        private bool _capturing;

        // Para que space no llame al evento del click del botón
        private bool _ignoreNextClick;

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public Keys SelectedKey
        {
            get { return _selectedKey; }
        }

        public event EventHandler KeyCaptured;

        public KeyCaptureControl()
        {
            Height = 35;
            Width = 180;

            _button = new Button
            {
                Text = "Presionar tecla...",
                Dock = DockStyle.Fill,
                BackColor = Color.LightGoldenrodYellow,
                TabStop = true
            };

            _button.Click += Button_Click;
            _button.PreviewKeyDown += Button_PreviewKeyDown;
            _button.KeyDown += Button_KeyDown;

            Controls.Add(_button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (_ignoreNextClick)
            {
                _ignoreNextClick = false;
                return;
            }

            BeginCapture();
        }

        private void BeginCapture()
        {
            if (_capturing)
                return;

            _capturing = true;
            _button.Text = "Presioná una tecla...";
            _button.BackColor = Color.LightGray;
            _button.Focus();
        }

        public void Clear()
        {
            _selectedKey = Keys.None;
            _capturing = false;
            _button.BackColor = Color.LightGoldenrodYellow;
            _button.Text = "Presionar tecla...";
        }

        private void Button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!_capturing)
                return;

            if (e.KeyCode == Keys.Space)
            {
                e.IsInputKey = true;
                return;
            }

            e.IsInputKey = true;
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_capturing)
                return;

            Keys key = e.KeyCode;

            if (key == Keys.ShiftKey)
            {
                if ((GetAsyncKeyState((int)Keys.RShiftKey) & 0x8000) != 0)
                    key = Keys.RShiftKey;
                else
                    key = Keys.LShiftKey;
            }
            else if (key == Keys.ControlKey)
            {
                if ((GetAsyncKeyState((int)Keys.RControlKey) & 0x8000) != 0)
                    key = Keys.RControlKey;
                else
                    key = Keys.LControlKey;
            }
            else if (key == Keys.Menu)
            {
                if ((GetAsyncKeyState((int)Keys.RMenu) & 0x8000) != 0)
                    key = Keys.RMenu;
                else
                    key = Keys.LMenu;
            }

            _selectedKey = key;

            _button.Text = GetDisplayName(_selectedKey);

            _capturing = false;

            KeyCaptured?.Invoke(
                this,
                EventArgs.Empty);

            if (e.KeyCode == Keys.Space)
            {
                _ignoreNextClick = true;
            }

            e.SuppressKeyPress = true;
            e.Handled = true;
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
    }
}