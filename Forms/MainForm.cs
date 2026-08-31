using KeyMaster.Core;
using KeyMaster.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyMaster
{
    public partial class MainForm : Form
    {
        private KeyboardHook _keyboardHook;

        private RemapManager _remapManager;

        public MainForm()
        {
            InitializeComponent();

            LoadKeys();

            _keyboardHook = new KeyboardHook();

            _keyboardHook.KeyDown += KeyboardHook_KeyDown;
            _keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _remapManager = new RemapManager();

            _keyboardHook.ShouldSuppressKey += ShouldSuppressKey;
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
                bool sent = KeySender.SendKey(target);

                if (!sent)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"ERROR enviando {target}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"Remapeo: {key} -> {target}");
                }

                return true;
            }

            return false;
        }

        private void LoadKeys()
        {
            var keys = KeyCatalog.GetKeys();

            cmbSource.DataSource = new List<KeyDefinition>(keys);
            cmbSource.DisplayMember = "DisplayName";
            cmbSource.ValueMember = "Key";

            cmbTarget.DataSource = new List<KeyDefinition>(keys);
            cmbTarget.DisplayMember = "DisplayName";
            cmbTarget.ValueMember = "Key";
        }

        private void btnAddRemap_Click(object sender, EventArgs e)
        {
            if (cmbSource.SelectedItem == null ||
        cmbTarget.SelectedItem == null)
            {
                return;
            }

            KeyDefinition sourceDefinition = (KeyDefinition)cmbSource.SelectedItem;
            KeyDefinition targetDefinition = (KeyDefinition)cmbTarget.SelectedItem;

            Keys source = sourceDefinition.Key;
            Keys target = targetDefinition.Key;

            bool added =
                _remapManager.AddRule(
                    source,
                    target);

            if (!added)
            {
                MessageBox.Show(
                    "No se puede crear este remapeo.",
                    "Remapeo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            RefreshRemapList();
        }
        private void RefreshRemapList()
        {
            lstRemaps.Items.Clear();

            foreach (RemapRule rule in _remapManager.Rules)
            {
                lstRemaps.Items.Add(rule);
            }
        }

        private void btnRemoveRemap_Click(object sender, EventArgs e)
        {
            if (lstRemaps.SelectedItem == null)
                return;

            RemapRule rule =
                (RemapRule)lstRemaps.SelectedItem;

            _remapManager.RemoveRule(
                rule.Source);

            RefreshRemapList();
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            _keyboardHook?.Dispose();

            base.OnFormClosed(e);
        }

        private void btnTestKey_Click(object sender, EventArgs e)
        {
            bool result = KeySender.SendKey(Keys.X);

            MessageBox.Show("Resultado: " + result);
        }
    }
}
