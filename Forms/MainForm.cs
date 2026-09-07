using KeyMaster.Controls;
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

        //private readonly List<HotkeyAction> _hotkeys = new List<HotkeyAction>();
        private List<HotkeyAction> _hotkeys
        {
            get
            {
                return _profileManager.ActiveProfile.Hotkeys;
            }
        }

        private readonly HashSet<Keys> _pressedKeys = new HashSet<Keys>();
        private readonly HashSet<HotkeyAction> _triggeredHotkeys = new HashSet<HotkeyAction>();

        private ProfileManager _profileManager;

        public MainForm()
        {
            InitializeComponent();

            LoadKeys();

            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyDown += KeyboardHook_KeyDown;
            _keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _profileManager = new ProfileManager();
            _remapManager = new RemapManager(_profileManager.ActiveProfile.Remaps);
            RefreshProfileList();

            _keyboardHook.ShouldSuppressKey += ShouldSuppressKey;

            cmbAction.SelectedIndex = 0;
            cmbAction_SelectedIndexChanged(cmbAction, EventArgs.Empty);
            cmbTextMethod.SelectedIndex = 0;
            cmbTextMethod_SelectedIndexChanged(cmbTextMethod, EventArgs.Empty);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            keyCaptureSource.KeyCaptured += KeyCaptureSource_KeyCaptured;
            keyCaptureTarget.KeyCaptured += KeyCaptureTarget_KeyCaptured;

            ConfigureKeyCaptureTooltips();
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

        private void ConfigureKeyCaptureTooltips()
        {
            string ttKeyPress = "Click Izquierdo del mouse y presionar tecla para asignar.\n" +
                                "Click Derecho del mouse para cancelar asignación.";

            keyCaptureSource.SetToolTipKCC(toolTipKeyPress, ttKeyPress);
            keyCaptureTarget.SetToolTipKCC(toolTipKeyPress, ttKeyPress);
            hotkeyCapture.SetToolTipHCC(toolTipKeyPress, ttKeyPress);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                _keyboardHook.Start();

                lblKH.Font = new System.Drawing.Font(lblKH.Font, System.Drawing.FontStyle.Bold);
                lblStatus.Text = "ACTIVO";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Font = new System.Drawing.Font(lblKH.Font, System.Drawing.FontStyle.Bold);
                lblStatus.Padding = new Padding(10, 0, 0, 0);
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

            lblKH.Font = new System.Drawing.Font(lblKH.Font, System.Drawing.FontStyle.Regular);
            lblStatus.Text = "DETENIDO";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Font = new System.Drawing.Font(lblKH.Font, System.Drawing.FontStyle.Regular);
            lblStatus.Padding = new Padding(0, 0, 0, 0);
        }

        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            lstKeys.Items.Add(
                $"DOWN: {e.KeyCode}");

            lstKeys.TopIndex = lstKeys.Items.Count - 1;

            if (_pressedKeys.Add(e.KeyCode))
            {
                CheckHotkeys(e.KeyCode);
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
                if (hotkey.Keys.All(
                    key => !_pressedKeys.Contains(key)))
                {
                    _triggeredHotkeys.Remove(hotkey);
                }
            }
        }

        private void CheckHotkeys(Keys pressedKey)
        {
            foreach (HotkeyAction hotkey in _hotkeys)
            {
                if (!hotkey.Enabled)
                    continue;

                if (!hotkey.Keys.Contains(pressedKey))
                    continue;

                if (hotkey.Keys.All(
                    key => _pressedKeys.Contains(key)))
                {
                    ExecuteHotkey(hotkey);
                    
                    return;
                }
            }
        }
        private void ExecuteHotkey(HotkeyAction hotkey)
        {
            if (hotkey.Action == "Abrir programa o archivo")
            {
                try
                {
                    System.Diagnostics.Process.Start(hotkey.Configuration);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo abrir el programa o archivo.\n\n" +
                        ex.Message,
                        "Hotkey",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            if (hotkey.Action == "Escribir texto")
            {
                if (hotkey.TextMethod == "Portapapeles")
                {
                    System.Threading.Tasks.Task.Run(() =>
                    {
                        KeySender.WaitForHotkeyRelease(hotkey.Keys);

                        this.BeginInvoke(new Action(() =>
                        {
                            KeySender.SendTextViaClipboard(hotkey.Configuration);
                        }));
                    });

                    return;
                }

                if (hotkey.TextMethod == "Teclado Unicode")
                {
                    KeySender.SendText(hotkey.Configuration);

                    return;
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
                lstRemaps.Items.Add(new RemapListItem(rule));
            }
        }

        private void btnRemoveRemap_Click(object sender, EventArgs e)
        {
            if (lstRemaps.SelectedItem == null)
                return;

            RemapListItem item = (RemapListItem)lstRemaps.SelectedItem;

            RemapRule rule = item.Rule;

            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que querés eliminar este remapeo?",
                "Eliminar remapeo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

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
            string textMethod = "";

            if (action == "Abrir programa o archivo")
            {
                if (string.IsNullOrWhiteSpace(txtProgram.Text))
                {
                    MessageBox.Show(
                        "Seleccioná un programa o archivo.",
                        "Hotkey",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                configuration = txtProgram.Text;
            }
            else if (action == "Escribir texto")
            {
                if (string.IsNullOrEmpty(txtHotkeyText.Text))
                {
                    MessageBox.Show(
                        "Escribí el texto que querés enviar.",
                        "Hotkey",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (cmbTextMethod.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Seleccioná un método.",
                        "Hotkey",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                configuration = txtHotkeyText.Text;
                textMethod = cmbTextMethod.SelectedItem.ToString();
            }

            HotkeyAction hotkey = new HotkeyAction();

            hotkey.Keys.AddRange(hotkeyCapture.SelectedKeys);

            hotkey.Action = action;
            hotkey.TextMethod = textMethod;
            hotkey.Configuration = configuration;
            hotkey.Enabled = true;

            _hotkeys.Add(hotkey);

            string hotkeyText = string.Join(
                " + ",
                hotkey.Keys.Select(
                    key => KeyCatalog.GetDisplayName(key)));

            string actionDisplay = hotkey.Action;
            if (hotkey.Action == "Escribir texto")
            {
                actionDisplay += " (" + hotkey.TextMethod + ")";
            }

            dgvHotkeys.Rows.Add(
                hotkeyText,
                actionDisplay,
                hotkey.Configuration,
                hotkey.Enabled ? "Sí" : "No");

            hotkeyCapture.Clear();
            txtProgram.Clear();
            txtHotkeyText.Clear();
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAction.SelectedItem == null)
                return;

            string action = cmbAction.SelectedItem.ToString();

            bool isProgram = action == "Abrir programa o archivo";

            bool isText = action == "Escribir texto";

            txtProgram.Visible = isProgram;
            btnBrowseProgram.Visible = isProgram;
            lblProgram.Visible = isProgram;

            txtHotkeyText.Visible = !isProgram;
            lblHotkeyText.Visible = !isProgram;

            lblTextMethod.Visible = isText;
            cmbTextMethod.Visible = isText;
        }

        private void cmbTextMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTextMethod.SelectedItem == null)
                return;
        }

        private void btnRemoveHotkey_Click(object sender, EventArgs e)
        {
            if (dgvHotkeys.SelectedRows.Count == 0)
                return;

            int index = dgvHotkeys.SelectedRows[0].Index;

            if (index < 0 || index >= _hotkeys.Count)
                return;

            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que querés eliminar esta hotkey?",
                "Eliminar hotkey",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _hotkeys.RemoveAt(index);

            dgvHotkeys.Rows.RemoveAt(index);
        }

        private void RefreshProfileList()
        {
            cmbProfiles.DataSource = null;
            cmbProfiles.DataSource = _profileManager.Profiles;
            cmbProfiles.DisplayMember = "Name";

            cmbProfiles.SelectedItem = _profileManager.ActiveProfile;
        }

        private void btnNewProfile_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingresá el nombre del nuevo perfil:",
                "Nuevo perfil",
                "Nuevo perfil");

            if (string.IsNullOrWhiteSpace(name))
                return;

            name = name.Trim();

            if (_profileManager.Profiles.Any(
                p => p.Name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "Ya existe un perfil con ese nombre.",
                    "Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Profile profile = new Profile
            {
                Name = name
            };

            _profileManager.Profiles.Add(profile);

            RefreshProfileList();
        }

        private void btnRenameProfile_Click(object sender, EventArgs e)
        {
            Profile profile = _profileManager.ActiveProfile;

            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingresá el nuevo nombre del perfil:",
                "Renombrar perfil",
                profile.Name);

            if (string.IsNullOrWhiteSpace(name))
                return;

            name = name.Trim();

            if (_profileManager.Profiles.Any(
                p => p != profile &&
                     p.Name.Equals(
                         name,
                         StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "Ya existe un perfil con ese nombre.",
                    "Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            profile.Name = name;

            RefreshProfileList();
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            Profile profile = _profileManager.ActiveProfile;

            if (_profileManager.Profiles.Count <= 1)
            {
                MessageBox.Show(
                    "No se puede eliminar el último perfil.",
                    "Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que querés eliminar el perfil \"" +
                profile.Name +
                "\"?",
                "Eliminar perfil",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _profileManager.Profiles.Remove(profile);

            Profile newActiveProfile = _profileManager.Profiles[0];

            _profileManager.SetActiveProfile(newActiveProfile);

            RefreshProfileList();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _keyboardHook?.Dispose();

            base.OnFormClosed(e);
        }
    }
}
