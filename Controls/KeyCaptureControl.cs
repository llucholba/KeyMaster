using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyMaster.Controls
{
    public class KeyCaptureControl : UserControl
    {
        private readonly Button _button;

        private Keys _selectedKey = Keys.None;
        private bool _capturing;

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

            // Le indicamos a WinForms que estas teclas
            // también deben considerarse teclas de entrada.
            e.IsInputKey = true;
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_capturing)
                return;

            _selectedKey = e.KeyCode;

            _button.Text = GetDisplayName(_selectedKey);

            _capturing = false;

            KeyCaptured?.Invoke(
                this,
                EventArgs.Empty);

            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private string GetDisplayName(Keys key)
        {
            switch (key)
            {
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