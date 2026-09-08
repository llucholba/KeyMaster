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

        private bool _loadingProfileList;

        public MainForm()
        {
            InitializeComponent();

            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyDown += KeyboardHook_KeyDown;
            _keyboardHook.KeyUp += KeyboardHook_KeyUp;

            _profileManager = new ProfileManager();
            _remapManager = new RemapManager(_profileManager.ActiveProfile.Remaps);

            RefreshRemapList();
            RefreshHotkeyList();

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

                btnStart.Enabled = false;
                btnStop.Enabled = true;
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

            btnStop.Enabled = false;
            btnStart.Enabled = true;
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

            _profileManager.SaveProfile(_profileManager.ActiveProfile);

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

            _profileManager.SaveProfile(_profileManager.ActiveProfile);

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

            _profileManager.SaveProfile(_profileManager.ActiveProfile);

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

            _profileManager.SaveProfile(_profileManager.ActiveProfile);

            dgvHotkeys.Rows.RemoveAt(index);
        }

        private void RefreshProfileList()
        {
            _loadingProfileList = true;

            try
            {
                cmbProfiles.DataSource = null;
                cmbProfiles.DataSource = _profileManager.Profiles;
                cmbProfiles.DisplayMember = "Name";

                cmbProfiles.SelectedItem = _profileManager.ActiveProfile;
            }
            finally
            {
                _loadingProfileList = false;
            }
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

            _profileManager.SaveProfile(profile);

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

            if (!_profileManager.RenameProfile(
                profile,
                name))
            {
                MessageBox.Show(
                    "No se pudo renombrar el perfil.\n\n" +
                    "Es posible que ya exista otro perfil con ese nombre.",
                    "Perfil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

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

            _profileManager.DeleteProfile(profile);

            ChangeActiveProfile(_profileManager.ActiveProfile);

            RefreshProfileList();
        }

        private void ChangeActiveProfile(Profile profile)
        {
            if (profile == null)
                return;

            _profileManager.SetActiveProfile(profile);

            _profileManager.SaveActiveProfileSetting();

            _remapManager.SetRules(profile.Remaps);

            RefreshRemapList();

            RefreshHotkeyList();
        }
        private void RefreshHotkeyList()
        {
            dgvHotkeys.Rows.Clear();

            foreach (HotkeyAction hotkey in _hotkeys)
            {
                string hotkeyText = string.Join(
                    " + ",
                    hotkey.Keys.Select(key => KeyCatalog.GetDisplayName(key)));

                string actionDisplay = hotkey.Action;

                if (hotkey.Action == "Escribir texto")
                {
                    actionDisplay +=
                        " (" + hotkey.TextMethod + ")";
                }

                dgvHotkeys.Rows.Add(
                    hotkeyText,
                    actionDisplay,
                    hotkey.Configuration,
                    hotkey.Enabled ? "Sí" : "No");
            }
        }

        private void cmbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loadingProfileList)
                return;

            if (cmbProfiles.SelectedItem == null)
                return;

            Profile profile = cmbProfiles.SelectedItem as Profile;

            if (profile == null)
                return;

            if (profile == _profileManager.ActiveProfile)
                return;

            ChangeActiveProfile(profile);
        }

        private void btnExportProfile_Click(object sender, EventArgs e)
        {
            Profile profile = _profileManager.ActiveProfile;

            if (profile == null)
                return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Exportar perfil";

                dialog.Filter = "Perfil de KeyMaster (*.json)|*.json";

                dialog.FileName = profile.Name + ".json";

                dialog.AddExtension = true;
                dialog.DefaultExt = "json";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ProfileStorage storage = new ProfileStorage();

                    storage.ExportProfile(
                        profile,
                        dialog.FileName);

                    MessageBox.Show(
                        "El perfil \"" +
                        profile.Name +
                        "\" fue exportado correctamente.",
                        "Exportar perfil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo exportar el perfil.\n\n" +
                        ex.Message,
                        "Exportar perfil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Importar perfil";

                dialog.Filter = "Perfil de KeyMaster (*.json)|*.json";

                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ProfileStorage storage = new ProfileStorage();

                    Profile profile =
                        storage.ImportProfile(
                            dialog.FileName);

                    if (profile == null)
                    {
                        MessageBox.Show(
                            "El archivo no contiene un perfil válido.",
                            "Importar perfil",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    bool imported =
                        _profileManager.ImportProfile(
                            profile);

                    if (!imported)
                    {
                        MessageBox.Show(
                            "Ya existe un perfil con el nombre \"" +
                            profile.Name +
                            "\".\n\n" +
                            "El perfil no fue importado.",
                            "Importar perfil",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    ChangeActiveProfile(profile);

                    RefreshProfileList();

                    MessageBox.Show(
                        "El perfil \"" +
                        profile.Name +
                        "\" fue importado correctamente.",
                        "Importar perfil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo importar el perfil.\n\n" +
                        ex.Message,
                        "Importar perfil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportAllProfiles_Click(object sender, EventArgs e)
        {
            if (_profileManager.Profiles.Count == 0)
                return;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Exportar todos los perfiles";

                dialog.Filter = "Respaldo de KeyMaster (*.json)|*.json";

                dialog.FileName = "KeyMaster_Backup.json";

                dialog.AddExtension = true;
                dialog.DefaultExt = "json";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ProfileStorage storage = new ProfileStorage();

                    storage.ExportAllProfiles(
                        _profileManager.Profiles,
                        dialog.FileName);

                    MessageBox.Show(
                        "Todos los perfiles fueron exportados correctamente.",
                        "Exportar perfiles",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudieron exportar los perfiles.\n\n" +
                        ex.Message,
                        "Exportar perfiles",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportAllProfiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Importar todos los perfiles";

                dialog.Filter = "Respaldo de KeyMaster (*.json)|*.json";

                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    ProfileStorage storage = new ProfileStorage();

                    ProfilePackage package =
                        storage.ImportAllProfiles(
                            dialog.FileName);

                    if (package == null)
                    {
                        MessageBox.Show(
                            "El archivo no contiene un respaldo válido.",
                            "Importar perfiles",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    if (package.FormatVersion != 1)
                    {
                        MessageBox.Show(
                            "La versión del respaldo no es compatible.",
                            "Importar perfiles",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    List<string> skippedProfiles = new List<string>();

                    List<string> importedProfiles = new List<string>();

                    int importedCount =
                        _profileManager.ImportAllProfiles(
                            package,
                            skippedProfiles,
                            importedProfiles);

                    RefreshProfileList();

                    string message = "";

                    if (importedProfiles.Count > 0)
                    {
                        message +=
                            "Perfiles agregados: " +
                            importedProfiles.Count +
                            "\n\n" +
                            string.Join(
                                "\n",
                                importedProfiles);
                    }

                    if (skippedProfiles.Count > 0)
                    {
                        if (message.Length > 0)
                            message += "\n\n";

                        message +=
                            "Perfiles omitidos porque ya existían: " +
                            skippedProfiles.Count +
                            "\n\n" +
                            string.Join(
                                "\n",
                                skippedProfiles);
                    }

                    if (importedProfiles.Count == 0 &&
                        skippedProfiles.Count == 0)
                    {
                        message =
                            "No se importaron perfiles.";
                    }

                    MessageBox.Show(
                        message,
                        "Importar perfiles",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudieron importar los perfiles.\n\n" +
                        ex.Message,
                        "Importar perfiles",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _keyboardHook?.Dispose();

            base.OnFormClosed(e);
        }
    }
}
