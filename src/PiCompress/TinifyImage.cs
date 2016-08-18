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
        internal static string ApiUrl = "https://api.tinify.com/shrink";
        public static int MaxCompressCount { get; } = 500;
        public List<TinifyApiKeyPair> ApiKeys { get; set; }
        public string SourceImagePath { get; set; }
        public int RepeatCompressionNumber { get; set; }
        public TinifyImage(string tinifyApiKey, string sourceImgPath) : this(tinifyApiKey, sourceImgPath, 1) { }
        public TinifyImage(string tinifyApiKey, string sourceImgPath, int repeatCompressionNo)
        {
            ApiKeys = new List<TinifyApiKeyPair>
            {
                TinifyApiKeyPair.Create(tinifyApiKey, CompressRemainCountAsync(tinifyApiKey).Result)
            };

            SourceImagePath = sourceImgPath;
            RepeatCompressionNumber = repeatCompressionNo;
        }
        public TinifyImage(List<TinifyApiKeyPair> tinifyApiKeys, string sourceImgPath): this(tinifyApiKeys, sourceImgPath, 1) { }
        public TinifyImage(List<TinifyApiKeyPair> tinifyApiKeys, string sourceImgPath, int repeatCompressionNo)
        {
            ApiKeys = tinifyApiKeys;
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
            byte[] resImg = File.ReadAllBytes(SourceImagePath);

            for (var repeatCount = 1; repeatCount <= RepeatCompressionNumber; repeatCount++)
            {
                using (var client = new WebClient())
                {
                    if (!ApiKeys.Any()) break;

                    var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{ApiKeys[0].Key}"));
                    client.Headers.Add(HttpRequestHeader.Authorization, $"Basic {auth}");

                    do
                    {
                        client.UploadData(ApiUrl, resImg);

                        // Compression was successful, retrieve output from Location header.
                        resImg = client.DownloadData(client.ResponseHeaders["Location"]);
                        ApiKeys[0].CompressCount = int.Parse(client.ResponseHeaders["Compression-Count"]);

                        // call progress event to new compress level
                        OnProgressChanged(RepeatCompressionNumber.GetPercent(repeatCount), resImg, ApiKeys[0].CompressCount);

                        if (ApiKeys[0].CompressRemainCount <= 0) ApiKeys.RemoveAt(0);
                    } while (++repeatCount <= RepeatCompressionNumber && ApiKeys.Any());
                }
            }

            return resImg.ConvertToImage();
        }

        public int CompressRemainCount()
        {
            return ApiKeys.Sum(x => x.CompressRemainCount);
        }

        public static async Task<int> CompressRemainCountAsync(string apiKey)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(TinifyImage.ApiUrl);
                client.Timeout = TimeSpan.FromSeconds(20);
                var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{apiKey}"));
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");

                // Construct an HttpContent from a StringContent
                HttpContent body = new StringContent("");

                // and add the header to this object instance
                // optional: add a formatter option to it as well
                // synchronous request without the need for .ContinueWith() or await
                HttpResponseMessage response = await client.PostAsync(TinifyImage.ApiUrl, body);
                var res = response.Headers.GetValues("Compression-Count").FirstOrDefault();

                int count;
                return Int32.TryParse(res, out count) ? count : 0;
            }
        }
    }
}