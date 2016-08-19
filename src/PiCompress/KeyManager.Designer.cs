namespace PiCompress
{
    partial class KeyManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbTinifyApiKeys = new System.Windows.Forms.GroupBox();
            this.dgvKeys = new System.Windows.Forms.DataGridView();
            this.colRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeyRemainCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTinifyApiKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTinifyApiKeys
            // 
            this.gbTinifyApiKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTinifyApiKeys.Controls.Add(this.dgvKeys);
            this.gbTinifyApiKeys.Location = new System.Drawing.Point(12, 12);
            this.gbTinifyApiKeys.Name = "gbTinifyApiKeys";
            this.gbTinifyApiKeys.Size = new System.Drawing.Size(693, 575);
            this.gbTinifyApiKeys.TabIndex = 0;
            this.gbTinifyApiKeys.TabStop = false;
            this.gbTinifyApiKeys.Text = "Tinify API Keys";
            // 
            // dgvKeys
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvKeys.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRow,
            this.colKeyName,
            this.colKeyValue,
            this.colKeyRemainCount});
            this.dgvKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeys.Location = new System.Drawing.Point(3, 18);
            this.dgvKeys.Name = "dgvKeys";
            this.dgvKeys.RowHeadersWidth = 35;
            this.dgvKeys.RowTemplate.Height = 24;
            this.dgvKeys.Size = new System.Drawing.Size(687, 554);
            this.dgvKeys.TabIndex = 0;
            // 
            // colRow
            // 
            this.colRow.Frozen = true;
            this.colRow.HeaderText = "Row";
            this.colRow.Name = "colRow";
            this.colRow.ReadOnly = true;
            this.colRow.Width = 50;
            // 
            // colKeyName
            // 
            this.colKeyName.HeaderText = "Name";
            this.colKeyName.Name = "colKeyName";
            this.colKeyName.Width = 150;
            // 
            // colKeyValue
            // 
            this.colKeyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKeyValue.HeaderText = "API Key";
            this.colKeyValue.Name = "colKeyValue";
            // 
            // colKeyRemainCount
            // 
            this.colKeyRemainCount.HeaderText = "Compress Remain Count";
            this.colKeyRemainCount.Name = "colKeyRemainCount";
            this.colKeyRemainCount.ReadOnly = true;
            this.colKeyRemainCount.Width = 150;
            // 
            // KeyManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 599);
            this.Controls.Add(this.gbTinifyApiKeys);
            this.Name = "KeyManager";
            this.Text = "KeyManager";
            this.Load += new System.EventHandler(this.KeyManager_Load);
            this.gbTinifyApiKeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTinifyApiKeys;
        private System.Windows.Forms.DataGridView dgvKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKeyRemainCount;
    }
}