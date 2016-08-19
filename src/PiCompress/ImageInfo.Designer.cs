namespace PiCompress
{
    partial class ImageInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picPanel = new System.Windows.Forms.PictureBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblCompressLevel = new System.Windows.Forms.Label();
            this.btnBrowseToSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // picPanel
            // 
            this.picPanel.BackColor = System.Drawing.Color.Snow;
            this.picPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanel.Location = new System.Drawing.Point(0, 0);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(220, 220);
            this.picPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPanel.TabIndex = 0;
            this.picPanel.TabStop = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.Maroon;
            this.lblSize.Location = new System.Drawing.Point(4, 4);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(33, 25);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSize.UseCompatibleTextRendering = true;
            // 
            // lblCompressLevel
            // 
            this.lblCompressLevel.AutoSize = true;
            this.lblCompressLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblCompressLevel.ForeColor = System.Drawing.Color.Green;
            this.lblCompressLevel.Location = new System.Drawing.Point(4, 32);
            this.lblCompressLevel.Name = "lblCompressLevel";
            this.lblCompressLevel.Size = new System.Drawing.Size(125, 17);
            this.lblCompressLevel.TabIndex = 2;
            this.lblCompressLevel.Text = "Compress Level: 0";
            this.lblCompressLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCompressLevel.Visible = false;
            // 
            // btnBrowseToSave
            // 
            this.btnBrowseToSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseToSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnBrowseToSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseToSave.Font = new System.Drawing.Font("Simplified Arabic Fixed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseToSave.Location = new System.Drawing.Point(140, 190);
            this.btnBrowseToSave.Name = "btnBrowseToSave";
            this.btnBrowseToSave.Size = new System.Drawing.Size(77, 27);
            this.btnBrowseToSave.TabIndex = 3;
            this.btnBrowseToSave.Text = "&Save";
            this.btnBrowseToSave.UseVisualStyleBackColor = false;
            this.btnBrowseToSave.Click += new System.EventHandler(this.btnBrowseToSave_Click);
            // 
            // ImageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.btnBrowseToSave);
            this.Controls.Add(this.lblCompressLevel);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.picPanel);
            this.Name = "ImageInfo";
            this.Size = new System.Drawing.Size(220, 220);
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPanel;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblCompressLevel;
        private System.Windows.Forms.Button btnBrowseToSave;
    }
}
