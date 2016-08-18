using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PiCompress
{
    public class TinifyImage
    {
        protected string ApiUrl = "https://api.tinify.com/shrink";
        protected string ApiKey { get; set; }
        public string SourceImagePath { get; set; }
        public int RepeatCompressionNumber { get; set; }
        public string TempFile { get; set; } = Path.GetTempFileName();
        public TinifyImage(string tinifyApiKey, string sourceImgPath) : this(tinifyApiKey, sourceImgPath, 1) { }
        public TinifyImage(string tinifyApiKey, string sourceImgPath, int repeatCompressionNo)
        {
            ApiKey = tinifyApiKey;
            SourceImagePath = sourceImgPath;
            RepeatCompressionNumber = repeatCompressionNo;
        }


        public delegate void ProgressChangedEventHandler(double elapsedPercent, byte[] currentLevelImage);
        public event ProgressChangedEventHandler ProgressChanged = delegate { };
        protected virtual void OnProgressChanged(double elapsedpercent, byte[] currentlevelimage)
        {
            ProgressChanged?.Invoke(elapsedpercent, currentlevelimage);
        }

        public Image Compress()
        {
            using (var client = new WebClient())
            {
                var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{ApiKey}"));
                client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + auth);

                var srcImg = File.ReadAllBytes(SourceImagePath);
                byte[] resImg = null;
                for (var repeatCount = 0; repeatCount < RepeatCompressionNumber; repeatCount++)
                {
                    client.UploadData(ApiUrl, srcImg);

                    // Compression was successful, retrieve output from Location header.
                    resImg = client.DownloadData(client.ResponseHeaders["Location"]);

                    // call progress event to new compress level
                    OnProgressChanged(GetPercent(repeatCount, RepeatCompressionNumber), resImg);
                }

                if (resImg == null) return null;

                using (var ms = new MemoryStream(resImg))
                {
                    return Image.FromStream(ms);
                }
            }
        }



        private double GetPercent(int count, int total)
        {
            return (double)count * 100 / total;
        }


    }
}
