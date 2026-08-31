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
            this.btnTestKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(158, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Keyboard Hook detenido";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(15, 50);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Location = new System.Drawing.Point(95, 50);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
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
            this.lstKeys.Location = new System.Drawing.Point(15, 100);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(155, 100);
            this.lstKeys.TabIndex = 3;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(12, 250);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(94, 16);
            this.lblSource.TabIndex = 4;
            this.lblSource.Text = "Tecla Original:";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(125, 247);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(121, 24);
            this.cmbSource.TabIndex = 5;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(12, 303);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(107, 16);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Reemplazar por:";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTarget
            // 
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Location = new System.Drawing.Point(125, 300);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(121, 24);
            this.cmbTarget.TabIndex = 7;
            // 
            // btnAddRemap
            // 
            this.btnAddRemap.Location = new System.Drawing.Point(80, 350);
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
            this.lstRemaps.Location = new System.Drawing.Point(15, 400);
            this.lstRemaps.Name = "lstRemaps";
            this.lstRemaps.Size = new System.Drawing.Size(231, 84);
            this.lstRemaps.TabIndex = 9;
            // 
            // btnRemoveRemap
            // 
            this.btnRemoveRemap.Location = new System.Drawing.Point(67, 500);
            this.btnRemoveRemap.Name = "btnRemoveRemap";
            this.btnRemoveRemap.Size = new System.Drawing.Size(150, 25);
            this.btnRemoveRemap.TabIndex = 10;
            this.btnRemoveRemap.Text = "Eliminar seleccionado";
            this.btnRemoveRemap.UseVisualStyleBackColor = true;
            this.btnRemoveRemap.Click += new System.EventHandler(this.btnRemoveRemap_Click);
            // 
            // btnTestKey
            // 
            this.btnTestKey.Location = new System.Drawing.Point(141, 526);
            this.btnTestKey.Name = "btnTestKey";
            this.btnTestKey.Size = new System.Drawing.Size(75, 23);
            this.btnTestKey.TabIndex = 11;
            this.btnTestKey.Text = "Test X";
            this.btnTestKey.UseVisualStyleBackColor = true;
            this.btnTestKey.Click += new System.EventHandler(this.btnTestKey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 561);
            this.Controls.Add(this.btnTestKey);
            this.Controls.Add(this.btnRemoveRemap);
            this.Controls.Add(this.lstRemaps);
            this.Controls.Add(this.btnAddRemap);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lstKeys);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnTestKey;
    }
}

