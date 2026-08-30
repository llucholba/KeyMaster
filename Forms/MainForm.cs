using System;
using System.Windows.Forms;
using KeyMaster.Core;
using KeyMaster.Models;

namespace KeyMaster
{
    public partial class MainForm : Form
    {
        private KeyboardHook _keyboardHook;

        private RemapManager _remapManager;

        public MainForm()
        {
            InitializeComponent();

            _keyboardHook = new KeyboardHook();

            _keyboardHook.KeyDown += KeyboardHook_KeyDown;
            _keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _remapManager = new RemapManager();

            _keyboardHook.ShouldSuppressKey += ShouldSuppressKey;

            _remapManager.AddRule(
                Keys.F1,
                Keys.F2);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _keyboardHook.Start();

                lblStatus.Text = "Estado: Keyboard Hook activo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo iniciar el Keyboard Hook.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _keyboardHook.Stop();

            lblStatus.Text = "Estado: Keyboard Hook detenido";
        }

        private void KeyboardHook_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            lstKeys.Items.Add(
                $"DOWN: {e.KeyCode}");

            lstKeys.TopIndex = lstKeys.Items.Count - 1;
        }

        private void KeyboardHook_KeyUp(
            object sender,
            KeyEventArgs e)
        {
            lstKeys.Items.Add(
                $"UP: {e.KeyCode}");

            lstKeys.TopIndex = lstKeys.Items.Count - 1;
        }

        private bool ShouldSuppressKey(Keys key)
        {
            if (_remapManager.TryGetTarget(key, out Keys target))
            {
                KeySender.SendKey(target);

                return true;
            }

            return false;
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            _keyboardHook?.Dispose();

            base.OnFormClosed(e);
        }
    }
}
