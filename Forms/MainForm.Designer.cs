namespace KeyMaster
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.btnAddRemap = new System.Windows.Forms.Button();
            this.lstRemaps = new System.Windows.Forms.ListBox();
            this.btnRemoveRemap = new System.Windows.Forms.Button();
            this.tabControlKM = new System.Windows.Forms.TabControl();
            this.tabPageRemaps = new System.Windows.Forms.TabPage();
            this.lblKH = new System.Windows.Forms.Label();
            this.keyCaptureTarget = new KeyMaster.Controls.KeyCaptureControl();
            this.keyCaptureSource = new KeyMaster.Controls.KeyCaptureControl();
            this.tabPageHotkeys = new System.Windows.Forms.TabPage();
            this.grpNewHotkey = new System.Windows.Forms.GroupBox();
            this.cmbTextMethod = new System.Windows.Forms.ComboBox();
            this.lblTextMethod = new System.Windows.Forms.Label();
            this.lblHotkeyText = new System.Windows.Forms.Label();
            this.txtHotkeyText = new System.Windows.Forms.TextBox();
            this.btnAddHotkey = new System.Windows.Forms.Button();
            this.hotkeyCapture = new KeyMaster.Controls.HotkeyCaptureControl();
            this.btnBrowseProgram = new System.Windows.Forms.Button();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.grpHotkeys = new System.Windows.Forms.GroupBox();
            this.btnRemoveHotkey = new System.Windows.Forms.Button();
            this.dgvHotkeys = new System.Windows.Forms.DataGridView();
            this.colHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageScripts = new System.Windows.Forms.TabPage();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.grpImportExportProfiles = new System.Windows.Forms.GroupBox();
            this.btnImportAllProfiles = new System.Windows.Forms.Button();
            this.lblCurrentProfile = new System.Windows.Forms.Label();
            this.btnExportAllProfiles = new System.Windows.Forms.Button();
            this.btnExportProfile = new System.Windows.Forms.Button();
            this.lblAllProfiles = new System.Windows.Forms.Label();
            this.btnImportProfile = new System.Windows.Forms.Button();
            this.grpProfileManagement = new System.Windows.Forms.GroupBox();
            this.cmbProfiles = new System.Windows.Forms.ComboBox();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.btnNewProfile = new System.Windows.Forms.Button();
            this.btnRenameProfile = new System.Windows.Forms.Button();
            this.toolTipKeyPress = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlKM.SuspendLayout();
            this.tabPageRemaps.SuspendLayout();
            this.tabPageHotkeys.SuspendLayout();
            this.grpNewHotkey.SuspendLayout();
            this.grpHotkeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotkeys)).BeginInit();
            this.tabPageConfig.SuspendLayout();
            this.grpImportExportProfiles.SuspendLayout();
            this.grpProfileManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(176, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "DETENIDO";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(9, 37);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(70, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(248, 37);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lstKeys
            // 
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.ItemHeight = 16;
            this.lstKeys.Items.AddRange(new object[] {
            "Lista de entradas de teclas"});
            this.lstKeys.Location = new System.Drawing.Point(9, 79);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(309, 100);
            this.lstKeys.TabIndex = 4;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 207);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(105, 16);
            this.lblSource.TabIndex = 4;
            this.lblSource.Text = "Tecla Deseada:";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(6, 257);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(91, 16);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Reemplaza a:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddRemap
            // 
            this.btnAddRemap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRemap.Location = new System.Drawing.Point(86, 300);
            this.btnAddRemap.Name = "btnAddRemap";
            this.btnAddRemap.Size = new System.Drawing.Size(150, 25);
            this.btnAddRemap.TabIndex = 7;
            this.btnAddRemap.Text = "Agregar remapeo";
            this.btnAddRemap.UseVisualStyleBackColor = true;
            this.btnAddRemap.Click += new System.EventHandler(this.btnAddRemap_Click);
            // 
            // lstRemaps
            // 
            this.lstRemaps.FormattingEnabled = true;
            this.lstRemaps.ItemHeight = 16;
            this.lstRemaps.Location = new System.Drawing.Point(9, 338);
            this.lstRemaps.Name = "lstRemaps";
            this.lstRemaps.Size = new System.Drawing.Size(309, 132);
            this.lstRemaps.TabIndex = 8;
            // 
            // btnRemoveRemap
            // 
            this.btnRemoveRemap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveRemap.Location = new System.Drawing.Point(86, 488);
            this.btnRemoveRemap.Name = "btnRemoveRemap";
            this.btnRemoveRemap.Size = new System.Drawing.Size(150, 25);
            this.btnRemoveRemap.TabIndex = 9;
            this.btnRemoveRemap.Text = "Eliminar Remapeo";
            this.btnRemoveRemap.UseVisualStyleBackColor = true;
            this.btnRemoveRemap.Click += new System.EventHandler(this.btnRemoveRemap_Click);
            // 
            // tabControlKM
            // 
            this.tabControlKM.Controls.Add(this.tabPageRemaps);
            this.tabControlKM.Controls.Add(this.tabPageHotkeys);
            this.tabControlKM.Controls.Add(this.tabPageScripts);
            this.tabControlKM.Controls.Add(this.tabPageConfig);
            this.tabControlKM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlKM.Location = new System.Drawing.Point(0, 0);
            this.tabControlKM.Name = "tabControlKM";
            this.tabControlKM.SelectedIndex = 0;
            this.tabControlKM.Size = new System.Drawing.Size(784, 561);
            this.tabControlKM.TabIndex = 1;
            // 
            // tabPageRemaps
            // 
            this.tabPageRemaps.AutoScroll = true;
            this.tabPageRemaps.Controls.Add(this.lblKH);
            this.tabPageRemaps.Controls.Add(this.lblStatus);
            this.tabPageRemaps.Controls.Add(this.btnRemoveRemap);
            this.tabPageRemaps.Controls.Add(this.keyCaptureTarget);
            this.tabPageRemaps.Controls.Add(this.lstRemaps);
            this.tabPageRemaps.Controls.Add(this.btnStart);
            this.tabPageRemaps.Controls.Add(this.btnAddRemap);
            this.tabPageRemaps.Controls.Add(this.keyCaptureSource);
            this.tabPageRemaps.Controls.Add(this.btnStop);
            this.tabPageRemaps.Controls.Add(this.lstKeys);
            this.tabPageRemaps.Controls.Add(this.lblTarget);
            this.tabPageRemaps.Controls.Add(this.lblSource);
            this.tabPageRemaps.Location = new System.Drawing.Point(4, 25);
            this.tabPageRemaps.Name = "tabPageRemaps";
            this.tabPageRemaps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRemaps.Size = new System.Drawing.Size(776, 532);
            this.tabPageRemaps.TabIndex = 0;
            this.tabPageRemaps.Text = "Remapeos";
            this.tabPageRemaps.UseVisualStyleBackColor = true;
            // 
            // lblKH
            // 
            this.lblKH.AutoSize = true;
            this.lblKH.Location = new System.Drawing.Point(73, 10);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(102, 16);
            this.lblKH.TabIndex = 10;
            this.lblKH.Text = "Keyboard Hook";
            this.lblKH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyCaptureTarget
            // 
            this.keyCaptureTarget.Cursor = System.Windows.Forms.Cursors.Help;
            this.keyCaptureTarget.Location = new System.Drawing.Point(117, 254);
            this.keyCaptureTarget.Name = "keyCaptureTarget";
            this.keyCaptureTarget.Size = new System.Drawing.Size(201, 24);
            this.keyCaptureTarget.TabIndex = 6;
            // 
            // keyCaptureSource
            // 
            this.keyCaptureSource.Cursor = System.Windows.Forms.Cursors.Help;
            this.keyCaptureSource.Location = new System.Drawing.Point(117, 204);
            this.keyCaptureSource.Name = "keyCaptureSource";
            this.keyCaptureSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyCaptureSource.Size = new System.Drawing.Size(201, 24);
            this.keyCaptureSource.TabIndex = 5;
            // 
            // tabPageHotkeys
            // 
            this.tabPageHotkeys.AutoScroll = true;
            this.tabPageHotkeys.Controls.Add(this.grpNewHotkey);
            this.tabPageHotkeys.Controls.Add(this.grpHotkeys);
            this.tabPageHotkeys.Location = new System.Drawing.Point(4, 25);
            this.tabPageHotkeys.Name = "tabPageHotkeys";
            this.tabPageHotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHotkeys.Size = new System.Drawing.Size(776, 532);
            this.tabPageHotkeys.TabIndex = 1;
            this.tabPageHotkeys.Text = "Hotkeys";
            this.tabPageHotkeys.UseVisualStyleBackColor = true;
            // 
            // grpNewHotkey
            // 
            this.grpNewHotkey.Controls.Add(this.cmbTextMethod);
            this.grpNewHotkey.Controls.Add(this.lblTextMethod);
            this.grpNewHotkey.Controls.Add(this.lblHotkeyText);
            this.grpNewHotkey.Controls.Add(this.txtHotkeyText);
            this.grpNewHotkey.Controls.Add(this.btnAddHotkey);
            this.grpNewHotkey.Controls.Add(this.hotkeyCapture);
            this.grpNewHotkey.Controls.Add(this.btnBrowseProgram);
            this.grpNewHotkey.Controls.Add(this.lblHotkey);
            this.grpNewHotkey.Controls.Add(this.txtProgram);
            this.grpNewHotkey.Controls.Add(this.lblAction);
            this.grpNewHotkey.Controls.Add(this.lblProgram);
            this.grpNewHotkey.Controls.Add(this.cmbAction);
            this.grpNewHotkey.Location = new System.Drawing.Point(6, 6);
            this.grpNewHotkey.Name = "grpNewHotkey";
            this.grpNewHotkey.Size = new System.Drawing.Size(762, 250);
            this.grpNewHotkey.TabIndex = 2;
            this.grpNewHotkey.TabStop = false;
            this.grpNewHotkey.Text = "Nueva Hotkey";
            // 
            // cmbTextMethod
            // 
            this.cmbTextMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTextMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTextMethod.FormattingEnabled = true;
            this.cmbTextMethod.Items.AddRange(new object[] {
            "Portapapeles",
            "Teclado Unicode"});
            this.cmbTextMethod.Location = new System.Drawing.Point(515, 87);
            this.cmbTextMethod.Name = "cmbTextMethod";
            this.cmbTextMethod.Size = new System.Drawing.Size(241, 24);
            this.cmbTextMethod.TabIndex = 12;
            this.cmbTextMethod.Visible = false;
            this.cmbTextMethod.SelectedIndexChanged += new System.EventHandler(this.cmbTextMethod_SelectedIndexChanged);
            // 
            // lblTextMethod
            // 
            this.lblTextMethod.AutoSize = true;
            this.lblTextMethod.Location = new System.Drawing.Point(453, 90);
            this.lblTextMethod.Name = "lblTextMethod";
            this.lblTextMethod.Size = new System.Drawing.Size(56, 16);
            this.lblTextMethod.TabIndex = 11;
            this.lblTextMethod.Text = "Método:";
            this.lblTextMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTextMethod.Visible = false;
            // 
            // lblHotkeyText
            // 
            this.lblHotkeyText.AutoSize = true;
            this.lblHotkeyText.Location = new System.Drawing.Point(6, 155);
            this.lblHotkeyText.Name = "lblHotkeyText";
            this.lblHotkeyText.Size = new System.Drawing.Size(44, 16);
            this.lblHotkeyText.TabIndex = 10;
            this.lblHotkeyText.Text = "Texto:";
            this.lblHotkeyText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHotkeyText
            // 
            this.txtHotkeyText.Location = new System.Drawing.Point(9, 174);
            this.txtHotkeyText.Multiline = true;
            this.txtHotkeyText.Name = "txtHotkeyText";
            this.txtHotkeyText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHotkeyText.Size = new System.Drawing.Size(747, 39);
            this.txtHotkeyText.TabIndex = 9;
            // 
            // btnAddHotkey
            // 
            this.btnAddHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHotkey.Location = new System.Drawing.Point(319, 219);
            this.btnAddHotkey.Name = "btnAddHotkey";
            this.btnAddHotkey.Size = new System.Drawing.Size(125, 25);
            this.btnAddHotkey.TabIndex = 7;
            this.btnAddHotkey.Text = "Agregar Hotkey";
            this.btnAddHotkey.UseVisualStyleBackColor = true;
            this.btnAddHotkey.Click += new System.EventHandler(this.btnAddHotkey_Click);
            // 
            // hotkeyCapture
            // 
            this.hotkeyCapture.Cursor = System.Windows.Forms.Cursors.Help;
            this.hotkeyCapture.Location = new System.Drawing.Point(9, 60);
            this.hotkeyCapture.Name = "hotkeyCapture";
            this.hotkeyCapture.Size = new System.Drawing.Size(301, 24);
            this.hotkeyCapture.TabIndex = 13;
            // 
            // btnBrowseProgram
            // 
            this.btnBrowseProgram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseProgram.Location = new System.Drawing.Point(669, 127);
            this.btnBrowseProgram.Name = "btnBrowseProgram";
            this.btnBrowseProgram.Size = new System.Drawing.Size(87, 23);
            this.btnBrowseProgram.TabIndex = 6;
            this.btnBrowseProgram.Text = "Examinar...";
            this.btnBrowseProgram.UseVisualStyleBackColor = true;
            this.btnBrowseProgram.Click += new System.EventHandler(this.btnBrowseProgram_Click);
            // 
            // lblHotkey
            // 
            this.lblHotkey.AutoSize = true;
            this.lblHotkey.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblHotkey.Location = new System.Drawing.Point(6, 41);
            this.lblHotkey.Name = "lblHotkey";
            this.lblHotkey.Size = new System.Drawing.Size(89, 16);
            this.lblHotkey.TabIndex = 0;
            this.lblHotkey.Text = "Combinación:";
            this.lblHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProgram
            // 
            this.txtProgram.Location = new System.Drawing.Point(9, 127);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.ReadOnly = true;
            this.txtProgram.Size = new System.Drawing.Size(654, 22);
            this.txtProgram.TabIndex = 5;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(453, 41);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(48, 16);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Acción";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgram
            // 
            this.lblProgram.AutoSize = true;
            this.lblProgram.Location = new System.Drawing.Point(6, 108);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(70, 16);
            this.lblProgram.TabIndex = 4;
            this.lblProgram.Text = "Programa:";
            this.lblProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbAction
            // 
            this.cmbAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Items.AddRange(new object[] {
            "Abrir programa o archivo",
            "Escribir texto",
            "Abrir carpeta (proximamente)"});
            this.cmbAction.Location = new System.Drawing.Point(456, 60);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(300, 24);
            this.cmbAction.TabIndex = 3;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // grpHotkeys
            // 
            this.grpHotkeys.Controls.Add(this.btnRemoveHotkey);
            this.grpHotkeys.Controls.Add(this.dgvHotkeys);
            this.grpHotkeys.Location = new System.Drawing.Point(6, 262);
            this.grpHotkeys.Name = "grpHotkeys";
            this.grpHotkeys.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpHotkeys.Size = new System.Drawing.Size(762, 262);
            this.grpHotkeys.TabIndex = 1;
            this.grpHotkeys.TabStop = false;
            this.grpHotkeys.Text = "Hotkeys configuradas";
            // 
            // btnRemoveHotkey
            // 
            this.btnRemoveHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveHotkey.Location = new System.Drawing.Point(319, 233);
            this.btnRemoveHotkey.Name = "btnRemoveHotkey";
            this.btnRemoveHotkey.Size = new System.Drawing.Size(125, 23);
            this.btnRemoveHotkey.TabIndex = 1;
            this.btnRemoveHotkey.Text = "Eliminar Hotkey";
            this.btnRemoveHotkey.UseVisualStyleBackColor = true;
            this.btnRemoveHotkey.Click += new System.EventHandler(this.btnRemoveHotkey_Click);
            // 
            // dgvHotkeys
            // 
            this.dgvHotkeys.AllowUserToAddRows = false;
            this.dgvHotkeys.AllowUserToDeleteRows = false;
            this.dgvHotkeys.AllowUserToResizeRows = false;
            this.dgvHotkeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHotkeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHotkey,
            this.colAction,
            this.colConfiguration,
            this.colEnabled});
            this.dgvHotkeys.Location = new System.Drawing.Point(9, 25);
            this.dgvHotkeys.MultiSelect = false;
            this.dgvHotkeys.Name = "dgvHotkeys";
            this.dgvHotkeys.ReadOnly = true;
            this.dgvHotkeys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHotkeys.Size = new System.Drawing.Size(747, 202);
            this.dgvHotkeys.TabIndex = 0;
            // 
            // colHotkey
            // 
            this.colHotkey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colHotkey.HeaderText = "Combinación";
            this.colHotkey.Name = "colHotkey";
            this.colHotkey.ReadOnly = true;
            this.colHotkey.Width = 111;
            // 
            // colAction
            // 
            this.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAction.HeaderText = "Acción";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.Width = 73;
            // 
            // colConfiguration
            // 
            this.colConfiguration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colConfiguration.HeaderText = "Configuración";
            this.colConfiguration.Name = "colConfiguration";
            this.colConfiguration.ReadOnly = true;
            this.colConfiguration.Width = 114;
            // 
            // colEnabled
            // 
            this.colEnabled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEnabled.HeaderText = "Ok?";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.Width = 56;
            // 
            // tabPageScripts
            // 
            this.tabPageScripts.AutoScroll = true;
            this.tabPageScripts.Location = new System.Drawing.Point(4, 25);
            this.tabPageScripts.Name = "tabPageScripts";
            this.tabPageScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScripts.Size = new System.Drawing.Size(776, 532);
            this.tabPageScripts.TabIndex = 2;
            this.tabPageScripts.Text = "Scripts";
            this.tabPageScripts.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.grpImportExportProfiles);
            this.tabPageConfig.Controls.Add(this.grpProfileManagement);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(776, 532);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // grpImportExportProfiles
            // 
            this.grpImportExportProfiles.Controls.Add(this.btnImportAllProfiles);
            this.grpImportExportProfiles.Controls.Add(this.lblCurrentProfile);
            this.grpImportExportProfiles.Controls.Add(this.btnExportAllProfiles);
            this.grpImportExportProfiles.Controls.Add(this.btnExportProfile);
            this.grpImportExportProfiles.Controls.Add(this.lblAllProfiles);
            this.grpImportExportProfiles.Controls.Add(this.btnImportProfile);
            this.grpImportExportProfiles.Location = new System.Drawing.Point(6, 110);
            this.grpImportExportProfiles.Name = "grpImportExportProfiles";
            this.grpImportExportProfiles.Size = new System.Drawing.Size(274, 164);
            this.grpImportExportProfiles.TabIndex = 6;
            this.grpImportExportProfiles.TabStop = false;
            this.grpImportExportProfiles.Text = "IMPORTAR / EXPORTAR";
            // 
            // btnImportAllProfiles
            // 
            this.btnImportAllProfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportAllProfiles.Location = new System.Drawing.Point(153, 135);
            this.btnImportAllProfiles.Name = "btnImportAllProfiles";
            this.btnImportAllProfiles.Size = new System.Drawing.Size(115, 23);
            this.btnImportAllProfiles.TabIndex = 11;
            this.btnImportAllProfiles.Text = "Importar todos";
            this.btnImportAllProfiles.UseVisualStyleBackColor = true;
            this.btnImportAllProfiles.Click += new System.EventHandler(this.btnImportAllProfiles_Click);
            // 
            // lblCurrentProfile
            // 
            this.lblCurrentProfile.AutoSize = true;
            this.lblCurrentProfile.Location = new System.Drawing.Point(98, 30);
            this.lblCurrentProfile.Name = "lblCurrentProfile";
            this.lblCurrentProfile.Size = new System.Drawing.Size(79, 16);
            this.lblCurrentProfile.TabIndex = 0;
            this.lblCurrentProfile.Text = "Perfil actual:";
            this.lblCurrentProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExportAllProfiles
            // 
            this.btnExportAllProfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportAllProfiles.Location = new System.Drawing.Point(6, 135);
            this.btnExportAllProfiles.Name = "btnExportAllProfiles";
            this.btnExportAllProfiles.Size = new System.Drawing.Size(115, 23);
            this.btnExportAllProfiles.TabIndex = 10;
            this.btnExportAllProfiles.Text = "Exportar todos";
            this.btnExportAllProfiles.UseVisualStyleBackColor = true;
            this.btnExportAllProfiles.Click += new System.EventHandler(this.btnExportAllProfiles_Click);
            // 
            // btnExportProfile
            // 
            this.btnExportProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportProfile.Location = new System.Drawing.Point(6, 54);
            this.btnExportProfile.Name = "btnExportProfile";
            this.btnExportProfile.Size = new System.Drawing.Size(75, 23);
            this.btnExportProfile.TabIndex = 7;
            this.btnExportProfile.Text = "Exportar";
            this.btnExportProfile.UseVisualStyleBackColor = true;
            this.btnExportProfile.Click += new System.EventHandler(this.btnExportProfile_Click);
            // 
            // lblAllProfiles
            // 
            this.lblAllProfiles.AutoSize = true;
            this.lblAllProfiles.Location = new System.Drawing.Point(80, 110);
            this.lblAllProfiles.Name = "lblAllProfiles";
            this.lblAllProfiles.Size = new System.Drawing.Size(115, 16);
            this.lblAllProfiles.TabIndex = 9;
            this.lblAllProfiles.Text = "Todos los perfiles";
            this.lblAllProfiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImportProfile
            // 
            this.btnImportProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportProfile.Location = new System.Drawing.Point(193, 54);
            this.btnImportProfile.Name = "btnImportProfile";
            this.btnImportProfile.Size = new System.Drawing.Size(75, 23);
            this.btnImportProfile.TabIndex = 8;
            this.btnImportProfile.Text = "Importar";
            this.btnImportProfile.UseVisualStyleBackColor = true;
            this.btnImportProfile.Click += new System.EventHandler(this.btnImportProfile_Click);
            // 
            // grpProfileManagement
            // 
            this.grpProfileManagement.Controls.Add(this.cmbProfiles);
            this.grpProfileManagement.Controls.Add(this.btnDeleteProfile);
            this.grpProfileManagement.Controls.Add(this.btnNewProfile);
            this.grpProfileManagement.Controls.Add(this.btnRenameProfile);
            this.grpProfileManagement.Location = new System.Drawing.Point(6, 6);
            this.grpProfileManagement.Name = "grpProfileManagement";
            this.grpProfileManagement.Size = new System.Drawing.Size(274, 85);
            this.grpProfileManagement.TabIndex = 5;
            this.grpProfileManagement.TabStop = false;
            this.grpProfileManagement.Text = "PERFIL";
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfiles.FormattingEnabled = true;
            this.cmbProfiles.Location = new System.Drawing.Point(6, 21);
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(262, 24);
            this.cmbProfiles.TabIndex = 1;
            this.cmbProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbProfiles_SelectedIndexChanged);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteProfile.Location = new System.Drawing.Point(193, 56);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProfile.TabIndex = 4;
            this.btnDeleteProfile.Text = "Eliminar";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // btnNewProfile
            // 
            this.btnNewProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewProfile.Location = new System.Drawing.Point(6, 56);
            this.btnNewProfile.Name = "btnNewProfile";
            this.btnNewProfile.Size = new System.Drawing.Size(75, 23);
            this.btnNewProfile.TabIndex = 2;
            this.btnNewProfile.Text = "Nuevo";
            this.btnNewProfile.UseVisualStyleBackColor = true;
            this.btnNewProfile.Click += new System.EventHandler(this.btnNewProfile_Click);
            // 
            // btnRenameProfile
            // 
            this.btnRenameProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenameProfile.Location = new System.Drawing.Point(87, 56);
            this.btnRenameProfile.Name = "btnRenameProfile";
            this.btnRenameProfile.Size = new System.Drawing.Size(100, 23);
            this.btnRenameProfile.TabIndex = 3;
            this.btnRenameProfile.Text = "Renombrar";
            this.btnRenameProfile.UseVisualStyleBackColor = true;
            this.btnRenameProfile.Click += new System.EventHandler(this.btnRenameProfile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControlKM);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlKM.ResumeLayout(false);
            this.tabPageRemaps.ResumeLayout(false);
            this.tabPageRemaps.PerformLayout();
            this.tabPageHotkeys.ResumeLayout(false);
            this.grpNewHotkey.ResumeLayout(false);
            this.grpNewHotkey.PerformLayout();
            this.grpHotkeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotkeys)).EndInit();
            this.tabPageConfig.ResumeLayout(false);
            this.grpImportExportProfiles.ResumeLayout(false);
            this.grpImportExportProfiles.PerformLayout();
            this.grpProfileManagement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lstKeys;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Button btnAddRemap;
        private System.Windows.Forms.ListBox lstRemaps;
        private System.Windows.Forms.Button btnRemoveRemap;
        private Controls.KeyCaptureControl keyCaptureSource;
        private Controls.KeyCaptureControl keyCaptureTarget;
        private System.Windows.Forms.TabControl tabControlKM;
        private System.Windows.Forms.TabPage tabPageRemaps;
        private System.Windows.Forms.TabPage tabPageHotkeys;
        private System.Windows.Forms.TabPage tabPageScripts;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.Label lblHotkey;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Button btnBrowseProgram;
        private System.Windows.Forms.Button btnAddHotkey;
        private System.Windows.Forms.GroupBox grpHotkeys;
        private System.Windows.Forms.DataGridView dgvHotkeys;
        private Controls.HotkeyCaptureControl hotkeyCapture;
        private System.Windows.Forms.GroupBox grpNewHotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnabled;
        private System.Windows.Forms.TextBox txtHotkeyText;
        private System.Windows.Forms.Label lblHotkeyText;
        private System.Windows.Forms.Label lblTextMethod;
        private System.Windows.Forms.ComboBox cmbTextMethod;
        private System.Windows.Forms.Label lblKH;
        private System.Windows.Forms.Button btnRemoveHotkey;
        private System.Windows.Forms.ToolTip toolTipKeyPress;
        private System.Windows.Forms.Button btnNewProfile;
        private System.Windows.Forms.ComboBox cmbProfiles;
        private System.Windows.Forms.Label lblCurrentProfile;
        private System.Windows.Forms.Button btnRenameProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.GroupBox grpProfileManagement;
        private System.Windows.Forms.GroupBox grpImportExportProfiles;
        private System.Windows.Forms.Button btnImportProfile;
        private System.Windows.Forms.Button btnExportProfile;
        private System.Windows.Forms.Button btnImportAllProfiles;
        private System.Windows.Forms.Button btnExportAllProfiles;
        private System.Windows.Forms.Label lblAllProfiles;
    }
}

