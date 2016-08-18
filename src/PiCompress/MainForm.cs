using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PiCompress.Properties;

namespace PiCompress
{
    public partial class MainForm : Form
    {
        private string _importPath;

        public MainForm()
        {
            InitializeComponent();
            //
            // Set Form Text Localization
            //
            gbImportImage.Text = Localization.Import_a_Larg_Image_png_jpg;
            btnBrowseInputImg.Text = Localization.BrowseLargeImage;
            btnCompress.Text = Localization.Compress;
            lblNumCompressLevel.Text = Localization.CompressLevel;
            gbResult.Text = Localization.CompressedImages;
            Text = Localization.AppTitle;
        }

        private void btnBrowseInputImg_Click(object sender, EventArgs e)
        {
            _importPath = GetImportedImagePath();
            if (_importPath != null)
            {
                picInput.ImageLocation = _importPath;
            }
        }

        private string GetImportedImagePath()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = Localization.OpenImageFileDialogTitle;
                ofd.Filter = Localization.FilterImageFiles;
                ofd.CheckFileExists = true;
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
            }
        }


        private void btnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (_importPath == null)
                {
                    btnBrowseInputImg.PerformClick();
                }

                if (_importPath == null) return;

                procCompressLevel.Value = 0;

                var tinify = new TinifyImage(Settings.Default.TinifyApiKey, _importPath, (int)numCompressLevel.Value);
                tinify.ProgressChanged += Tinify_ProgressChanged;
                var result = tinify.Compress();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void Tinify_ProgressChanged(double elapsedPercent, byte[] currentLevelImage, int compressionCount)
        {
            procCompressLevel.Value = (int)elapsedPercent;

            var pic = new PictureBox
            {
                Image = currentLevelImage.ConvertToImage(),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(200, 200)
            };

            this.Text = $"{Localization.AppTitle} - {Localization.CompressRemainCount}: {TinifyHelperExtensions.MaxCompressCount - compressionCount}";
            flPanel.Controls.Add(pic);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var tinify = new TinifyImage(Settings.Default.TinifyApiKey, _importPath, (int)numCompressLevel.Value);
            this.Text = $"{Localization.AppTitle} - {Localization.CompressRemainCount}: {TinifyHelperExtensions.MaxCompressCount - await tinify.CompressRemainCountAsync()}";
        }
    }
}
