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
            if (_importPath == null)
            {
                btnBrowseInputImg.PerformClick();
            }

            if (_importPath == null) return;



        }
    }
}
