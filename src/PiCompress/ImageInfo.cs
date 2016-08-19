using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PiCompress.Properties;

namespace PiCompress
{
    public partial class ImageInfo : UserControl
    {
        public ImageInfo()
        {
            InitializeComponent();
        }

        public ImageInfo(int level) : this()
        {
            if (DesignMode) return;

            lblCompressLevel.Text = $"{Localization.CompressLevel}: {level}";
            lblCompressLevel.Visible = true;
        }

        private void btnBrowseToSave_Click(object sender, EventArgs e)
        {
            if (picPanel.Image == null) return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = Localization.SaveImageFileDialogTitle;
                sfd.Filter = Localization.FilterImageFiles;
                sfd.FileName = $"output.{picPanel.Image.GetExtension()}";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    picPanel.Image.Save(sfd.FileName);
                }
            }
        }

        public void SetImage(byte[] imgArray)
        {
            if (imgArray == null || !imgArray.Any()) return;

            lblSize.Text = imgArray.LongLength.CalcMemoryMensurableUnit();
            picPanel.Image = imgArray.ConvertToImage();
        }

        public void SetImage(string imgPath)
        {
            var imgArray = File.ReadAllBytes(imgPath);

            SetImage(imgArray);
        }
    }
}
