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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.btnAddRemap = new System.Windows.Forms.Button();
            this.lstRemaps = new System.Windows.Forms.ListBox();
            this.btnRemoveRemap = new System.Windows.Forms.Button();
            this.tabControlKM = new System.Windows.Forms.TabControl();
            this.tabPageRemaps = new System.Windows.Forms.TabPage();
            this.keyCaptureTarget = new KeyMaster.Controls.KeyCaptureControl();
            this.keyCaptureSource = new KeyMaster.Controls.KeyCaptureControl();
            this.tabPageHotkeys = new System.Windows.Forms.TabPage();
            this.grpNewHotkey = new System.Windows.Forms.GroupBox();
            this.btnAddHotkey = new System.Windows.Forms.Button();
            this.hotkeyCapture = new KeyMaster.Controls.HotkeyCaptureControl();
            this.btnBrowseProgram = new System.Windows.Forms.Button();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.grpHotkeys = new System.Windows.Forms.GroupBox();
            this.dgvHotkeys = new System.Windows.Forms.DataGridView();
            this.colHotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageScripts = new System.Windows.Forms.TabPage();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.txtHotkeyText = new System.Windows.Forms.TextBox();
            this.lblHotkeyText = new System.Windows.Forms.Label();
            this.tabControlKM.SuspendLayout();
            this.tabPageRemaps.SuspendLayout();
            this.tabPageHotkeys.SuspendLayout();
            this.grpNewHotkey.SuspendLayout();
            this.grpHotkeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotkeys)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(84, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(158, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Keyboard Hook detenido";
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
            "F1",
            "F2",
            "A",
            "Ctrl",
            "Shift",
            "T"});
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
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(117, 180);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(201, 24);
            this.cmbSource.TabIndex = 5;
            this.cmbSource.Visible = false;
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
            // cmbTarget
            // 
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Location = new System.Drawing.Point(117, 228);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(201, 24);
            this.cmbTarget.TabIndex = 7;
            this.cmbTarget.Visible = false;
            // 
            // btnAddRemap
            // 
            this.btnAddRemap.Location = new System.Drawing.Point(101, 300);
            this.btnAddRemap.Name = "btnAddRemap";
            this.btnAddRemap.Size = new System.Drawing.Size(125, 25);
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
            this.btnRemoveRemap.Location = new System.Drawing.Point(9, 488);
            this.btnRemoveRemap.Name = "btnRemoveRemap";
            this.btnRemoveRemap.Size = new System.Drawing.Size(150, 25);
            this.btnRemoveRemap.TabIndex = 9;
            this.btnRemoveRemap.Text = "Eliminar seleccionado";
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
            this.tabPageRemaps.Controls.Add(this.cmbTarget);
            this.tabPageRemaps.Controls.Add(this.lblSource);
            this.tabPageRemaps.Controls.Add(this.cmbSource);
            this.tabPageRemaps.Location = new System.Drawing.Point(4, 25);
            this.tabPageRemaps.Name = "tabPageRemaps";
            this.tabPageRemaps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRemaps.Size = new System.Drawing.Size(776, 532);
            this.tabPageRemaps.TabIndex = 0;
            this.tabPageRemaps.Text = "Remaps";
            this.tabPageRemaps.UseVisualStyleBackColor = true;
            // 
            // keyCaptureTarget
            // 
            this.keyCaptureTarget.Location = new System.Drawing.Point(117, 254);
            this.keyCaptureTarget.Name = "keyCaptureTarget";
            this.keyCaptureTarget.Size = new System.Drawing.Size(201, 24);
            this.keyCaptureTarget.TabIndex = 6;
            // 
            // keyCaptureSource
            // 
            this.keyCaptureSource.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.hotkeyCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hotkeyCapture.Location = new System.Drawing.Point(9, 60);
            this.hotkeyCapture.Name = "hotkeyCapture";
            this.hotkeyCapture.Size = new System.Drawing.Size(300, 24);
            this.hotkeyCapture.TabIndex = 8;
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
            "Abrir programa",
            "Escribir texto",
            "Abrir archivo",
            "Abrir carpeta",
            "Ejecutar comando",
            "Copiar texto",
            "Pegar texto"});
            this.cmbAction.Location = new System.Drawing.Point(456, 60);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(300, 24);
            this.cmbAction.TabIndex = 3;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            // 
            // grpHotkeys
            // 
            this.grpHotkeys.Controls.Add(this.dgvHotkeys);
            this.grpHotkeys.Location = new System.Drawing.Point(6, 262);
            this.grpHotkeys.Name = "grpHotkeys";
            this.grpHotkeys.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpHotkeys.Size = new System.Drawing.Size(762, 262);
            this.grpHotkeys.TabIndex = 1;
            this.grpHotkeys.TabStop = false;
            this.grpHotkeys.Text = "Hotkeys configuradas";
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
            this.dgvHotkeys.Size = new System.Drawing.Size(747, 231);
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
            this.tabPageConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(776, 532);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lstKeys;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTarget;
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
    }
}

