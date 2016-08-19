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
            this.panelBackground = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).BeginInit();
            this.panelBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPanel
            // 
            this.picPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPanel.BackColor = System.Drawing.Color.Snow;
            this.picPanel.Location = new System.Drawing.Point(3, 3);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(230, 159);
            this.picPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPanel.TabIndex = 0;
            this.picPanel.TabStop = false;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.Maroon;
            this.lblSize.Location = new System.Drawing.Point(3, 171);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(33, 25);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSize.UseCompatibleTextRendering = true;
            // 
            // lblCompressLevel
            // 
            this.lblCompressLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCompressLevel.AutoSize = true;
            this.lblCompressLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblCompressLevel.ForeColor = System.Drawing.Color.Green;
            this.lblCompressLevel.Location = new System.Drawing.Point(3, 198);
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
            this.btnBrowseToSave.Location = new System.Drawing.Point(163, 168);
            this.btnBrowseToSave.Name = "btnBrowseToSave";
            this.btnBrowseToSave.Size = new System.Drawing.Size(70, 49);
            this.btnBrowseToSave.TabIndex = 3;
            this.btnBrowseToSave.Text = "&Save";
            this.btnBrowseToSave.UseVisualStyleBackColor = false;
            this.btnBrowseToSave.Click += new System.EventHandler(this.btnBrowseToSave_Click);
            // 
            // panelBackground
            // 
            this.panelBackground.Controls.Add(this.lblSize);
            this.panelBackground.Controls.Add(this.lblCompressLevel);
            this.panelBackground.Controls.Add(this.btnBrowseToSave);
            this.panelBackground.Controls.Add(this.picPanel);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(236, 220);
            this.panelBackground.TabIndex = 4;
            // 
            // ImageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.panelBackground);
            this.Name = "ImageInfo";
            this.Size = new System.Drawing.Size(236, 220);
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.panelBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPanel;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblCompressLevel;
        private System.Windows.Forms.Button btnBrowseToSave;
        private System.Windows.Forms.Panel panelBackground;
    }
}
