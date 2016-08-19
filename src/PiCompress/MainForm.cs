using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using PiCompress.Properties;

namespace PiCompress
{
    public partial class MainForm : Form
    {
        private string _importPath;
        private List<TinifyApiKeyPair> _lstKeys;
        private int _lastComressionLevel = 0;
        private CancellationTokenSource _cts;
        private string _appVersion;
        
        public MainForm()
        {
            InitializeComponent();
            //
            // Set Form Text Localization
            //
            _appVersion = $"v{Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)}";
            gbImportImage.Text = Localization.Import_a_Larg_Image_png_jpg;
            btnBrowseInputImg.Text = Localization.BrowseLargeImage;
            btnCompress.Text = $"{Localization.Compress} {Localization.RightArrow}";
            lblNumCompressLevel.Text = $"{Localization.CompressLevel}:";
            gbResult.Text = Localization.CompressedImages;
            btnKeyManager.Text = Localization.KeyManager;
            btnCancel.Text = $"{Localization.Cancel} {Localization.CancelSymbol}";
            Text = $"{Localization.AppTitle} {_appVersion}";
        }


        private string GetImportImagePath()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = Localization.OpenImageFileDialogTitle;
                ofd.Filter = Localization.FilterImageFiles;
                ofd.CheckFileExists = true;
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
            }
        }

        private void Tinify_ProgressChanged(int compressLevel, byte[] currentLevelImage, int compressionCount)
        {
            _lastComressionLevel = compressLevel;
            var elapsedPercent = ((int)numCompressLevel.Value).GetPercent(compressLevel);
            procCompressLevel.Value = (int)elapsedPercent;

            var pic = new ImageInfo(compressLevel);
            pic.SetImage(currentLevelImage);

            this.Text = $"{Localization.AppTitle} {_appVersion} - {Localization.CompressRemainCount}: {_lstKeys.Sum(x => x.CompressRemainCount)}";
            flPanel.Controls.Add(pic);
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _lstKeys = await TinifyHelperExtensions.GenerateTinifyApiKeysAsync();
                var tinify = new TinifyImage(_lstKeys, _importPath);
                Text = $"{Localization.AppTitle} {_appVersion} - {Localization.CompressRemainCount}: {tinify.CompressRemainCount()}";
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
        private async void btnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                numCompressLevel.Enabled = false;
                btnBrowseInputImg.Enabled = false;
                btnCancel.Enabled = true;
                Cursor = Cursors.WaitCursor;

                if (_importPath == null)
                {
                    btnBrowseInputImg.PerformClick();
                }

                if (_importPath == null) return;

                procCompressLevel.Value = 0;

                var tinify = new TinifyImage(_lstKeys, _importPath, (int)numCompressLevel.Value);
                tinify.ProgressChanged += Tinify_ProgressChanged;
                var result = await tinify.CompressAsync(_cts = new CancellationTokenSource());
                picOutput.SetImage(result);
                procCompressLevel.Value = procCompressLevel.Maximum;
                MessageBox.Show(_cts.IsCancellationRequested 
                    ? Localization.ProcessCanceledByUser
                    : _lastComressionLevel < numCompressLevel.Value
                    ? Localization.MoreNotCompact_CompresstionCompleted
                    : Localization.CompressCompleted);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                numCompressLevel.Enabled = true;
                btnCancel.Enabled = false;
                btnBrowseInputImg.Enabled = true;
            }
        }
        private void btnBrowseInputImg_Click(object sender, EventArgs e)
        {
            var path = GetImportImagePath();
            if (path == null) return;

            _importPath = path;
            picInput.SetImage(_importPath);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }
        private void btnKeyManager_Click(object sender, EventArgs e)
        {
            var keysForm = new KeyManager();
            keysForm.Show();
        }
    }
}
