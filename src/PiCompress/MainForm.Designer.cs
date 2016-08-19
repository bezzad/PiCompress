namespace PiCompress
{
    partial class MainForm
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
            this.gbImportImage = new System.Windows.Forms.GroupBox();
            this.picOutput = new PiCompress.ImageInfo();
            this.picInput = new PiCompress.ImageInfo();
            this.procCompressLevel = new System.Windows.Forms.ProgressBar();
            this.btnCompress = new System.Windows.Forms.Button();
            this.lblNumCompressLevel = new System.Windows.Forms.Label();
            this.numCompressLevel = new System.Windows.Forms.NumericUpDown();
            this.btnBrowseInputImg = new System.Windows.Forms.Button();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gbImportImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompressLevel)).BeginInit();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImportImage
            // 
            this.gbImportImage.Controls.Add(this.picOutput);
            this.gbImportImage.Controls.Add(this.picInput);
            this.gbImportImage.Controls.Add(this.procCompressLevel);
            this.gbImportImage.Controls.Add(this.btnCompress);
            this.gbImportImage.Controls.Add(this.lblNumCompressLevel);
            this.gbImportImage.Controls.Add(this.numCompressLevel);
            this.gbImportImage.Controls.Add(this.btnBrowseInputImg);
            this.gbImportImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbImportImage.Location = new System.Drawing.Point(0, 0);
            this.gbImportImage.Margin = new System.Windows.Forms.Padding(4);
            this.gbImportImage.Name = "gbImportImage";
            this.gbImportImage.Padding = new System.Windows.Forms.Padding(4);
            this.gbImportImage.Size = new System.Drawing.Size(857, 331);
            this.gbImportImage.TabIndex = 0;
            this.gbImportImage.TabStop = false;
            this.gbImportImage.Text = "Import a Large Image (.png or .jpg)";
            // 
            // picOutput
            // 
            this.picOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picOutput.BackColor = System.Drawing.Color.Snow;
            this.picOutput.Location = new System.Drawing.Point(629, 41);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(220, 220);
            this.picOutput.TabIndex = 8;
            // 
            // picInput
            // 
            this.picInput.BackColor = System.Drawing.Color.Snow;
            this.picInput.Location = new System.Drawing.Point(236, 41);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(220, 220);
            this.picInput.TabIndex = 7;
            // 
            // procCompressLevel
            // 
            this.procCompressLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.procCompressLevel.Location = new System.Drawing.Point(13, 287);
            this.procCompressLevel.Margin = new System.Windows.Forms.Padding(4);
            this.procCompressLevel.Name = "procCompressLevel";
            this.procCompressLevel.Size = new System.Drawing.Size(836, 28);
            this.procCompressLevel.TabIndex = 5;
            // 
            // btnCompress
            // 
            this.btnCompress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCompress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompress.Enabled = false;
            this.btnCompress.Location = new System.Drawing.Point(478, 124);
            this.btnCompress.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(128, 46);
            this.btnCompress.TabIndex = 4;
            this.btnCompress.Text = "&Compress →";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // lblNumCompressLevel
            // 
            this.lblNumCompressLevel.AutoSize = true;
            this.lblNumCompressLevel.Location = new System.Drawing.Point(32, 208);
            this.lblNumCompressLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumCompressLevel.Name = "lblNumCompressLevel";
            this.lblNumCompressLevel.Size = new System.Drawing.Size(113, 17);
            this.lblNumCompressLevel.TabIndex = 3;
            this.lblNumCompressLevel.Text = "Compress Level:";
            // 
            // numCompressLevel
            // 
            this.numCompressLevel.Location = new System.Drawing.Point(153, 206);
            this.numCompressLevel.Margin = new System.Windows.Forms.Padding(4);
            this.numCompressLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCompressLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCompressLevel.Name = "numCompressLevel";
            this.numCompressLevel.Size = new System.Drawing.Size(61, 22);
            this.numCompressLevel.TabIndex = 2;
            this.numCompressLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnBrowseInputImg
            // 
            this.btnBrowseInputImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseInputImg.Location = new System.Drawing.Point(68, 41);
            this.btnBrowseInputImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseInputImg.Name = "btnBrowseInputImg";
            this.btnBrowseInputImg.Size = new System.Drawing.Size(128, 108);
            this.btnBrowseInputImg.TabIndex = 1;
            this.btnBrowseInputImg.Text = "Browse Large Image";
            this.btnBrowseInputImg.UseVisualStyleBackColor = true;
            this.btnBrowseInputImg.Click += new System.EventHandler(this.btnBrowseInputImg_Click);
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.flPanel);
            this.gbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResult.Location = new System.Drawing.Point(0, 331);
            this.gbResult.Margin = new System.Windows.Forms.Padding(4);
            this.gbResult.Name = "gbResult";
            this.gbResult.Padding = new System.Windows.Forms.Padding(4);
            this.gbResult.Size = new System.Drawing.Size(857, 291);
            this.gbResult.TabIndex = 1;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Compressed Images";
            // 
            // flPanel
            // 
            this.flPanel.AutoScroll = true;
            this.flPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanel.Location = new System.Drawing.Point(4, 19);
            this.flPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(849, 268);
            this.flPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 622);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbImportImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(844, 518);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbImportImage.ResumeLayout(false);
            this.gbImportImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompressLevel)).EndInit();
            this.gbResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImportImage;
        private System.Windows.Forms.Button btnBrowseInputImg;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Label lblNumCompressLevel;
        private System.Windows.Forms.NumericUpDown numCompressLevel;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.FlowLayoutPanel flPanel;
        private System.Windows.Forms.ProgressBar procCompressLevel;
        private ImageInfo picInput;
        private ImageInfo picOutput;
    }
}

