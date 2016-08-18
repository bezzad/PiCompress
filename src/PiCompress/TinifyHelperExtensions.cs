using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using PiCompress.Properties;

namespace PiCompress
{
    public static class TinifyHelperExtensions
    {
        public static double GetPercent(this int total, int count)
        {
            return (double)count * 100 / total;
        }

        public static Image ConvertToImage(this byte[] imgData)
        {
            if (imgData == null) return null;

            using (var ms = new MemoryStream(imgData))
            {
                return Image.FromStream(ms);
            }
        }

        public static async Task<List<TinifyApiKeyPair>> GenerateTinifyApiKeysAsync()
        {
            var lst = new List<TinifyApiKeyPair>();

            for (var index = 1; index <= Settings.Default.Properties.Count; index++)
            {
                var tinifyKey = Settings.Default[$"TinifyApiKey{index}"].ToString();
                var count = await TinifyImage.CompressRemainCountAsync(tinifyKey);
                if (count < TinifyImage.MaxCompressCount)
                {
                    lst.Add(TinifyApiKeyPair.Create(tinifyKey, count));
                }
            }

            return lst;
        }

        public static async Task<string> GenerateApiKey()
        {
            for (var index = 1; index <= Settings.Default.PropertyValues.Count; index++)
            {
                var tinifyKey = Settings.Default[$"TinifyApiKey{index}"].ToString();
                var count = await TinifyImage.CompressRemainCountAsync(tinifyKey);
                if (count < TinifyImage.MaxCompressCount) return tinifyKey;
            }

            return null;
        }
    }
}
