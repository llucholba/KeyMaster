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
                    return "Shift izquierdo";

                case Keys.RShiftKey:
                    return "Shift derecho";

                case Keys.LControlKey:
                    return "Ctrl izquierdo";

                case Keys.RControlKey:
                    return "Ctrl derecho";

                case Keys.LMenu:
                    return "Alt izquierdo";

                case Keys.RMenu:
                    return "Alt derecho";

                case Keys.Enter:
                    return "Enter";

                case Keys.Tab:
                    return "Tab";

                case Keys.Space:
                    return "Space";

                case Keys.Escape:
                    return "Escape";

                case Keys.Back:
                    return "Backspace";

                case Keys.Delete:
                    return "Delete";

                case Keys.Insert:
                    return "Insert";

                case Keys.Home:
                    return "Home";

                case Keys.End:
                    return "End";

                case Keys.PageUp:
                    return "Page Up";

                case Keys.PageDown:
                    return "Page Down";

                default:
                    return key.ToString();
            }
        }
    }
}