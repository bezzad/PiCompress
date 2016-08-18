﻿namespace PiCompress
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
            this.picInput = new System.Windows.Forms.PictureBox();
            this.btnBrowseInputImg = new System.Windows.Forms.Button();
            this.numCompressLevel = new System.Windows.Forms.NumericUpDown();
            this.lblNumCompressLevel = new System.Windows.Forms.Label();
            this.btnCompress = new System.Windows.Forms.Button();
            this.gbImportImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompressLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // gbImportImage
            // 
            this.gbImportImage.Controls.Add(this.btnCompress);
            this.gbImportImage.Controls.Add(this.lblNumCompressLevel);
            this.gbImportImage.Controls.Add(this.numCompressLevel);
            this.gbImportImage.Controls.Add(this.btnBrowseInputImg);
            this.gbImportImage.Controls.Add(this.picInput);
            this.gbImportImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbImportImage.Location = new System.Drawing.Point(0, 0);
            this.gbImportImage.Name = "gbImportImage";
            this.gbImportImage.Size = new System.Drawing.Size(544, 276);
            this.gbImportImage.TabIndex = 0;
            this.gbImportImage.TabStop = false;
            this.gbImportImage.Text = "Import a Large Image (.png or .jpg)";
            // 
            // picInput
            // 
            this.picInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.picInput.Location = new System.Drawing.Point(214, 16);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(327, 257);
            this.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInput.TabIndex = 0;
            this.picInput.TabStop = false;
            // 
            // btnBrowseInputImg
            // 
            this.btnBrowseInputImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseInputImg.Location = new System.Drawing.Point(51, 33);
            this.btnBrowseInputImg.Name = "btnBrowseInputImg";
            this.btnBrowseInputImg.Size = new System.Drawing.Size(96, 88);
            this.btnBrowseInputImg.TabIndex = 1;
            this.btnBrowseInputImg.Text = "Browse Large Image";
            this.btnBrowseInputImg.UseVisualStyleBackColor = true;
            this.btnBrowseInputImg.Click += new System.EventHandler(this.btnBrowseInputImg_Click);
            // 
            // numCompressLevel
            // 
            this.numCompressLevel.Location = new System.Drawing.Point(115, 167);
            this.numCompressLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCompressLevel.Name = "numCompressLevel";
            this.numCompressLevel.Size = new System.Drawing.Size(62, 20);
            this.numCompressLevel.TabIndex = 2;
            this.numCompressLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumCompressLevel
            // 
            this.lblNumCompressLevel.AutoSize = true;
            this.lblNumCompressLevel.Location = new System.Drawing.Point(24, 169);
            this.lblNumCompressLevel.Name = "lblNumCompressLevel";
            this.lblNumCompressLevel.Size = new System.Drawing.Size(85, 13);
            this.lblNumCompressLevel.TabIndex = 3;
            this.lblNumCompressLevel.Text = "Compress Level:";
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(51, 213);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(96, 37);
            this.btnCompress.TabIndex = 4;
            this.btnCompress.Text = "&Compress";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 708);
            this.Controls.Add(this.gbImportImage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.gbImportImage.ResumeLayout(false);
            this.gbImportImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompressLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbImportImage;
        private System.Windows.Forms.Button btnBrowseInputImg;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Label lblNumCompressLevel;
        private System.Windows.Forms.NumericUpDown numCompressLevel;
    }
}
