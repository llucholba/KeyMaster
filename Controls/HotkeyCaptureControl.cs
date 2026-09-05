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
