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

        public void Clear()
        {
            _selectedKey = Keys.None;
            _capturing = false;
            _button.BackColor = Color.LightGoldenrodYellow;
            _button.Text = "Presionar tecla...";
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
            _button.KeyDown += Button_KeyDown;

            Controls.Add(_button);
        }

        private void Button_Click(
            object sender,
            EventArgs e)
        {
            BeginCapture();
        }

        private void BeginCapture()
        {
            _capturing = true;
            _button.Text = "Presioná una tecla...";
            _button.BackColor = Color.LightGray;
            _button.Focus();
        }

        private void Button_KeyDown(
            object sender,
            KeyEventArgs e)
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
            return key.ToString();
        }
    }
}