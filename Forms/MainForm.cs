using KeyMaster.Core;
using KeyMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KeyMaster
{
    public partial class MainForm : Form
    {
        private KeyboardHook _keyboardHook;

        private RemapManager _remapManager;

        private readonly List<HotkeyAction> _hotkeys = new List<HotkeyAction>();

        private readonly HashSet<Keys> _pressedKeys = new HashSet<Keys>();
        private readonly HashSet<HotkeyAction> _triggeredHotkeys = new HashSet<HotkeyAction>();

        public MainForm()
        {
            InitializeComponent();

            LoadKeys();

            _keyboardHook = new KeyboardHook();

            _keyboardHook.KeyDown += KeyboardHook_KeyDown;
            _keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _remapManager = new RemapManager();

            _keyboardHook.ShouldSuppressKey += ShouldSuppressKey;

            cmbAction.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            keyCaptureSource.KeyCaptured += KeyCaptureSource_KeyCaptured;
            keyCaptureTarget.KeyCaptured += KeyCaptureTarget_KeyCaptured;
        }
        private void KeyCaptureSource_KeyCaptured(object sender, EventArgs e)
        {
            Keys key = keyCaptureSource.SelectedKey;

            System.Diagnostics.Debug.WriteLine("Source: " + key);
        }
        private void KeyCaptureTarget_KeyCaptured(object sender, EventArgs e)
        {
            Keys key = keyCaptureTarget.SelectedKey;

            System.Diagnostics.Debug.WriteLine("Target: " + key);
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

        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            lstKeys.Items.Add(
                $"DOWN: {e.KeyCode}");

            lstKeys.TopIndex = lstKeys.Items.Count - 1;

            if (_pressedKeys.Add(e.KeyCode))
            {
                CheckHotkeys();
            }
        }

        private void KeyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            lstKeys.Items.Add(
                $"UP: {e.KeyCode}");

            lstKeys.TopIndex = lstKeys.Items.Count - 1;

            _pressedKeys.Remove(e.KeyCode);

            foreach (HotkeyAction hotkey in _hotkeys)
            {
                if (!hotkey.Keys.Contains(e.KeyCode))
                    continue;

                _triggeredHotkeys.Remove(hotkey);
            }
        }

        private void CheckHotkeys()
        {
            foreach (HotkeyAction hotkey in _hotkeys)
            {
                if (!hotkey.Enabled)
                    continue;

                if (hotkey.Keys.All(
                    key => _pressedKeys.Contains(key)))
                {
                    if (_triggeredHotkeys.Contains(hotkey))
                        continue;

                    _triggeredHotkeys.Add(hotkey);

                    ExecuteHotkey(hotkey);

                    return;
                }
            }
        }
        private void ExecuteHotkey(HotkeyAction hotkey)
        {
            if (hotkey.Action == "Abrir programa")
            {
                try
                {
                    System.Diagnostics.Process.Start(hotkey.Configuration);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo abrir el programa.\n\n" +
                        ex.Message,
                        "Hotkey",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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
            Keys source = keyCaptureSource.SelectedKey;
            Keys target = keyCaptureTarget.SelectedKey;

            if (source == Keys.None ||
                target == Keys.None)
            {
                MessageBox.Show(
                    "Debés seleccionar la tecla original y la tecla de reemplazo.",
                    "Remapeo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

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

            keyCaptureSource.Clear();
            keyCaptureTarget.Clear();
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

            RemapRule rule = (RemapRule)lstRemaps.SelectedItem;

            _remapManager.RemoveRule(rule.Source);

            RefreshRemapList();
        }

        private void btnBrowseProgram_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Seleccionar programa";
                dialog.Filter = "Programas (*.exe)|*.exe|Todos los archivos (*.*)|*.*";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtProgram.Text = dialog.FileName;
                }
            }
        }

        private void btnAddHotkey_Click(object sender, EventArgs e)
        {
            if (hotkeyCapture.SelectedKeys.Count == 0)
            {
                MessageBox.Show(
                    "Primero presioná una combinación de teclas.",
                    "Hotkey",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbAction.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccioná una acción.",
                    "Hotkey",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string action = cmbAction.SelectedItem.ToString();

            string configuration = "";

            if (action == "Abrir programa")
            {
                if (string.IsNullOrWhiteSpace(txtProgram.Text))
                {
                    MessageBox.Show(
                        "Seleccioná un programa.",
                        "Hotkey",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                configuration = txtProgram.Text;
            }

            HotkeyAction hotkey = new HotkeyAction();

            hotkey.Keys.AddRange(hotkeyCapture.SelectedKeys);

            hotkey.Action = action;
            hotkey.Configuration = configuration;
            hotkey.Enabled = true;

            _hotkeys.Add(hotkey);

            string hotkeyText = string.Join(
                " + ",
                hotkey.Keys.Select(
                    key => GetHotkeyDisplayName(key)));

            dgvHotkeys.Rows.Add(
                hotkeyText,
                hotkey.Action,
                hotkey.Configuration,
                hotkey.Enabled ? "Sí" : "No");

            hotkeyCapture.Clear();
            txtProgram.Clear();
        }
        private string GetHotkeyDisplayName(Keys key)
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _keyboardHook?.Dispose();

            base.OnFormClosed(e);
        }
    }
}
