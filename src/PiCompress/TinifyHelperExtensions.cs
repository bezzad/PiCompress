using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
