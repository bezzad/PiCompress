using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PiCompress.Properties;

namespace PiCompress
{
    public partial class MainForm : Form
    {
        private string _importPath;
        private List<TinifyApiKeyPair> _lstKeys;


        public MainForm()
        {
            InitializeComponent();
            //
            // Set Form Text Localization
            //
            gbImportImage.Text = Localization.Import_a_Larg_Image_png_jpg;
            btnBrowseInputImg.Text = Localization.BrowseLargeImage;
            btnCompress.Text = $"{Localization.Compress} {Localization.RightArrow}";
            lblNumCompressLevel.Text = $"{Localization.CompressLevel}:";
            gbResult.Text = Localization.CompressedImages;
            Text = Localization.AppTitle;
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

        private void btnBrowseInputImg_Click(object sender, EventArgs e)
        {
            _importPath = GetImportedImagePath();
            if (_importPath != null)
            {
                picInput.SetImage(_importPath);
            }
        }
        private async void btnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                numCompressLevel.Enabled = false;
                btnBrowseInputImg.Enabled = false;
                Cursor = Cursors.WaitCursor;

                if (_importPath == null)
                {
                    btnBrowseInputImg.PerformClick();
                }

                if (_importPath == null) return;

                procCompressLevel.Value = 0;

                var tinify = new TinifyImage(_lstKeys, _importPath, (int)numCompressLevel.Value);
                tinify.ProgressChanged += Tinify_ProgressChanged;
                var result = await tinify.CompressAsync();
                picOutput.SetImage(result);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                numCompressLevel.Enabled = true;
                btnBrowseInputImg.Enabled = true;
            }
        }
        private void Tinify_ProgressChanged(int compressLevel, byte[] currentLevelImage, int compressionCount)
        {
            var elapsedPercent = ((int)numCompressLevel.Value).GetPercent(compressLevel);
            procCompressLevel.Value = (int)elapsedPercent;

            var pic = new ImageInfo(compressLevel);
            pic.SetImage(currentLevelImage);

            this.Text = $"{Localization.AppTitle} - {Localization.CompressRemainCount}: {_lstKeys.Sum(x => x.CompressRemainCount)}";
            flPanel.Controls.Add(pic);
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _lstKeys = await TinifyHelperExtensions.GenerateTinifyApiKeysAsync();
                var tinify = new TinifyImage(_lstKeys, _importPath);
                Text = $"{Localization.AppTitle} - {Localization.CompressRemainCount}: {tinify.CompressRemainCount()}";
                btnCompress.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
