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
            this.keyCaptureTarget = new KeyMaster.Controls.KeyCaptureControl();
            this.keyCaptureSource = new KeyMaster.Controls.KeyCaptureControl();
            this.tabControlKM = new System.Windows.Forms.TabControl();
            this.tabPageRemaps = new System.Windows.Forms.TabPage();
            this.tabPageHotkeys = new System.Windows.Forms.TabPage();
            this.tabPageScripts = new System.Windows.Forms.TabPage();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tabControlKM.SuspendLayout();
            this.tabPageRemaps.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(79, 10);
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
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Location = new System.Drawing.Point(241, 37);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 23);
            this.btnStop.TabIndex = 2;
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
            this.lstKeys.Size = new System.Drawing.Size(302, 100);
            this.lstKeys.TabIndex = 3;
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
            this.cmbSource.Size = new System.Drawing.Size(169, 24);
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
            this.cmbTarget.Size = new System.Drawing.Size(169, 24);
            this.cmbTarget.TabIndex = 7;
            this.cmbTarget.Visible = false;
            // 
            // btnAddRemap
            // 
            this.btnAddRemap.Location = new System.Drawing.Point(96, 300);
            this.btnAddRemap.Name = "btnAddRemap";
            this.btnAddRemap.Size = new System.Drawing.Size(125, 25);
            this.btnAddRemap.TabIndex = 8;
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
            this.lstRemaps.Size = new System.Drawing.Size(302, 132);
            this.lstRemaps.TabIndex = 9;
            // 
            // btnRemoveRemap
            // 
            this.btnRemoveRemap.Location = new System.Drawing.Point(9, 480);
            this.btnRemoveRemap.Name = "btnRemoveRemap";
            this.btnRemoveRemap.Size = new System.Drawing.Size(150, 25);
            this.btnRemoveRemap.TabIndex = 10;
            this.btnRemoveRemap.Text = "Eliminar seleccionado";
            this.btnRemoveRemap.UseVisualStyleBackColor = true;
            this.btnRemoveRemap.Click += new System.EventHandler(this.btnRemoveRemap_Click);
            // 
            // keyCaptureTarget
            // 
            this.keyCaptureTarget.Location = new System.Drawing.Point(117, 254);
            this.keyCaptureTarget.Name = "keyCaptureTarget";
            this.keyCaptureTarget.Size = new System.Drawing.Size(194, 24);
            this.keyCaptureTarget.TabIndex = 0;
            this.keyCaptureTarget.TabStop = false;
            // 
            // keyCaptureSource
            // 
            this.keyCaptureSource.Cursor = System.Windows.Forms.Cursors.Default;
            this.keyCaptureSource.Location = new System.Drawing.Point(117, 204);
            this.keyCaptureSource.Name = "keyCaptureSource";
            this.keyCaptureSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.keyCaptureSource.Size = new System.Drawing.Size(194, 24);
            this.keyCaptureSource.TabIndex = 0;
            this.keyCaptureSource.TabStop = false;
            // 
            // tabControlKM
            // 
            this.tabControlKM.Controls.Add(this.tabPageRemaps);
            this.tabControlKM.Controls.Add(this.tabPageHotkeys);
            this.tabControlKM.Controls.Add(this.tabPageScripts);
            this.tabControlKM.Controls.Add(this.tabPageConfig);
            this.tabControlKM.Location = new System.Drawing.Point(5, 10);
            this.tabControlKM.Name = "tabControlKM";
            this.tabControlKM.SelectedIndex = 0;
            this.tabControlKM.Size = new System.Drawing.Size(325, 540);
            this.tabControlKM.TabIndex = 11;
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
            this.tabPageRemaps.Size = new System.Drawing.Size(317, 511);
            this.tabPageRemaps.TabIndex = 0;
            this.tabPageRemaps.Text = "Remaps";
            this.tabPageRemaps.UseVisualStyleBackColor = true;
            // 
            // tabPageHotkeys
            // 
            this.tabPageHotkeys.AutoScroll = true;
            this.tabPageHotkeys.Location = new System.Drawing.Point(4, 25);
            this.tabPageHotkeys.Name = "tabPageHotkeys";
            this.tabPageHotkeys.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHotkeys.Size = new System.Drawing.Size(317, 511);
            this.tabPageHotkeys.TabIndex = 1;
            this.tabPageHotkeys.Text = "Hotkeys";
            this.tabPageHotkeys.UseVisualStyleBackColor = true;
            // 
            // tabPageScripts
            // 
            this.tabPageScripts.AutoScroll = true;
            this.tabPageScripts.Location = new System.Drawing.Point(4, 25);
            this.tabPageScripts.Name = "tabPageScripts";
            this.tabPageScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScripts.Size = new System.Drawing.Size(300, 508);
            this.tabPageScripts.TabIndex = 2;
            this.tabPageScripts.Text = "Scripts";
            this.tabPageScripts.UseVisualStyleBackColor = true;
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Location = new System.Drawing.Point(4, 25);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(300, 508);
            this.tabPageConfig.TabIndex = 3;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 561);
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
    }
}

