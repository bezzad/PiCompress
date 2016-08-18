using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        public delegate void ProgressChangedEventHandler(double elapsedPercent, byte[] currentLevelImage, int compressionCount);
        public event ProgressChangedEventHandler ProgressChanged = delegate { };
        protected virtual void OnProgressChanged(double elapsedpercent, byte[] currentlevelimage, int compressionCount)
        {
            ProgressChanged?.Invoke(elapsedpercent, currentlevelimage, compressionCount);
        }

        public Image Compress()
        {
            using (var client = new WebClient())
            {
                var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{ApiKey}"));
                client.Headers.Add(HttpRequestHeader.Authorization, $"Basic {auth}");

                var srcImg = File.ReadAllBytes(SourceImagePath);
                byte[] resImg = null;
                for (var repeatCount = 1; repeatCount <= RepeatCompressionNumber; repeatCount++)
                {
                    client.UploadData(ApiUrl, srcImg);

                    // Compression was successful, retrieve output from Location header.
                    resImg = client.DownloadData(client.ResponseHeaders["Location"]);
                    var count = int.Parse(client.ResponseHeaders["Compression-Count"]);

                    // call progress event to new compress level
                    OnProgressChanged(RepeatCompressionNumber.GetPercent(repeatCount), resImg, count);
                }

                return resImg.ConvertToImage();
            }
        }
        
        public async Task<int> CompressRemainCountAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.Timeout = TimeSpan.FromSeconds(20);
                var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{ApiKey}"));
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");

                // Construct an HttpContent from a StringContent
                HttpContent body = new StringContent("");

                // and add the header to this object instance
                // optional: add a formatter option to it as well
                // synchronous request without the need for .ContinueWith() or await
                HttpResponseMessage response = await client.PostAsync(ApiUrl, body);
                var res = response.Headers.GetValues("Compression-Count").FirstOrDefault();

                int count;
                return int.TryParse(res, out count) ? count : 0;
            }
        }
    }
}
