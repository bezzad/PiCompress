using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
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

            foreach (SettingsProperty prop in Settings.Default.Properties)
            {
                var tinifyKey = prop.DefaultValue.ToString();
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

        public static string CalcMemoryMensurableUnit(this double bigUnSignedNumber)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-US");

            var kb = bigUnSignedNumber / 1024; // · 1024 Bytes = 1 Kilobyte 
            var mb = kb / 1024; // · 1024 Kilobytes = 1 Megabyte 
            var gb = mb / 1024; // · 1024 Megabytes = 1 Gigabyte 
            var tb = gb / 1024; // · 1024 Gigabytes = 1 Terabyte 
                                //var pb = tb / 1024; // · 1024 Terabytes = 1 Petabyte 
                                //var eb = pb / 1024; // · 1024 Petabytes = 1 Exabyte
                                //var zb = eb / 1024; // · 1024 Exabytes = 1 Zettabyte 
                                //var yb = zb / 1024; // · 1024 Zettabytes = 1 Yottabyte 
                                //var bb = yb / 1024; // · 1024 Yottabytes = 1 Brontobyte
                                //var geoB = bb / 1024; // · 1024 Brontobytes = 1 Geopbyte
                                //var saganB = geoB / 1024; // . Saganbyte = 1024 Geopbyte
                                //var pijaB = saganB / 1024; // . Pijabyte = 1024 Saganbyte 
                                //var alphaB = pijaB / 1024; // . Alphabyte = 1024 Pijabyte 
                                //var kryatB = alphaB / 1024; // . Kryatbyte = 1024 Alphabyte 
                                //var amosB = kryatB / 1024; // . Amosbyte = 1024 Kryatbyte 
                                //var pectrolB = amosB / 1024; // . Pectrolbyte = 1024 Amosbyte
                                //var bolgerB = pectrolB / 1024; // . Bolgerbyte = 1024 Pectrolbyte 
                                //var samboB = bolgerB / 1024; // . Sambobyte = 1024 Bolgerbyte
                                //var quesaB = samboB / 1024; // . Quesabyte = 1024 Sambobyte 
                                //var kinsaB = quesaB / 1024; // . Kinsabyte = 1024 Quesabyte 
                                //var rutherB = kinsaB / 1024; // . Rutherbyte = 1024 Kinsabyte 
                                //var dubniB = rutherB / 1024; // . Dubnibyte = 1024 Rutherbyte 
                                //var seaborgB = dubniB / 1024; // . Seaborgbyte = 1024 Dubnibyte 
                                //var bohrB = seaborgB / 1024; // . Bohrbyte = 1024 Seaborgbyte 
                                //var hassiuB = bohrB / 1024; // . Hassiubyte = 1024 Bohrbyte 
                                //var meitnerbyte = hassiuB / 1024; // . Meitnerbyte = 1024 Hassiubyte
                                //var darmstadbyte = meitnerbyte / 1024; // . Darmstadbyte = 1024 Meitnerbyte
                                //var roentbyte = darmstadbyte / 1024; // . Roentbyte = 1024 Darmstadbyte
                                //var coperbyte = roentbyte / 1024; // . Coperbyte = 1024 Roentbyte 
                                //var koentekbyte = coperbyte / 1024; // . Koentekbyte = 1024 Coperbyte 
                                //var silvanikbyte = koentekbyte / 1024; // . Silvanikbyte = 1024 Koentekbyte 
                                //var golvanikbyte = silvanikbyte / 1024; // . Golvanikbyte = 1024 Silvanikbyte 
                                //var platvanikbyte = golvanikbyte / 1024; // . Platvanikbyte = 1024 Golvanikbyte 
                                //var einstanikbyte = platvanikbyte / 1024; // . Einstanikbyte = 1024 Platvanikbyte 
                                //var emeranikbyte = einstanikbyte / 1024; // . Emeranikbyte = 1024 Einstanikbyte 
                                //var rubanikbyte = emeranikbyte / 1024; // . Rubanikbyte = 1024 Emeranikbyte 
                                //var diamonikbyte = rubanikbyte / 1024; // . Diamonikbyte = 1024 Rubanikbyte 
                                //var amazonikbyte = diamonikbyte / 1024; // . Amazonikbyte = 1024 Diamonikbyte 
                                //var nilevanikbyte = amazonikbyte / 1024; // . Nilevanikbyte = 1024 Amazonikbyte 
                                //var infinitybyte = nilevanikbyte / 1024; // . Infinitybyte = 1024 Nilevanikbyte 
                                //var websitebyte = infinitybyte / 1024; // . Websitebyte = 1024 Infinitybyte

            return 
            //       websitebyte > 1 ? string.Format(culture, "{0:N0} Websitebyte", websitebyte) :
            //       infinitybyte > 1 ? string.Format(culture, "{0:N0} Infinitybyte", infinitybyte) :
            //       nilevanikbyte > 1 ? string.Format(culture, "{0:N0} Nilevanikbyte", nilevanikbyte) :
            //       amazonikbyte > 1 ? string.Format(culture, "{0:N0} Amazonikbyte", amazonikbyte) :
            //       diamonikbyte > 1 ? string.Format(culture, "{0:N0} Diamonikbyte", diamonikbyte) :
            //       rubanikbyte > 1 ? string.Format(culture, "{0:N0} Rubanikbyte", rubanikbyte) :
            //       emeranikbyte > 1 ? string.Format(culture, "{0:N0} Emeranikbyte", emeranikbyte) :
            //       einstanikbyte > 1 ? string.Format(culture, "{0:N0} Einstanikbyte", einstanikbyte) :
            //       platvanikbyte > 1 ? string.Format(culture, "{0:N0} Platvanikbyte", platvanikbyte) :
            //       golvanikbyte > 1 ? string.Format(culture, "{0:N0} Golvanikbyte", golvanikbyte) :
            //       silvanikbyte > 1 ? string.Format(culture, "{0:N0} Silvanikbyte", silvanikbyte) :
            //       koentekbyte > 1 ? string.Format(culture, "{0:N0} Koentekbyte", koentekbyte) :
            //       coperbyte > 1 ? string.Format(culture, "{0:N0} Coperbyte", coperbyte) :
            //       roentbyte > 1 ? string.Format(culture, "{0:N0} Roentbyte", roentbyte) :
            //       darmstadbyte > 1 ? string.Format(culture, "{0:N0} Darmstadbyte", darmstadbyte) :
            //       meitnerbyte > 1 ? string.Format(culture, "{0:N0} Meitnerbyte", meitnerbyte) :
            //       hassiuB > 1 ? string.Format(culture, "{0:N0} Hassiubyte", hassiuB) :
            //       bohrB > 1 ? string.Format(culture, "{0:N0} Bohrbyte", bohrB) :
            //       seaborgB > 1 ? string.Format(culture, "{0:N0} Seaborgbyte", seaborgB) :
            //       dubniB > 1 ? string.Format(culture, "{0:N0} Dubnibyte", dubniB) :
            //       rutherB > 1 ? string.Format(culture, "{0:N0} Rutherbyte", rutherB) :
            //       kinsaB > 1 ? string.Format(culture, "{0:N0} Kinsabyte", kinsaB) :
            //       quesaB > 1 ? string.Format(culture, "{0:N0} Quesabyte", quesaB) :
            //       samboB > 1 ? string.Format(culture, "{0:N0} Sambobyte", samboB) :
            //       bolgerB > 1 ? string.Format(culture, "{0:N0} Bolgerbyte", bolgerB) :
            //       pectrolB > 1 ? string.Format(culture, "{0:N0} Pectrolbyte", pectrolB) :
            //       amosB > 1 ? string.Format(culture, "{0:N0} Amosbyte", amosB) :
            //       kryatB > 1 ? string.Format(culture, "{0:N0} Kryatbyte", kryatB) :
            //       alphaB > 1 ? string.Format(culture, "{0:N0} Alphabyte", alphaB) :
            //       pijaB > 1 ? string.Format(culture, "{0:N0} Pijabyte", pijaB) :
            //       saganB > 1 ? string.Format(culture, "{0:N0} Saganbyte", saganB) :
            //       geoB > 1 ? string.Format(culture, "{0:N0} Geopbyte", geoB) :
            //       bb > 1 ? string.Format(culture, "{0:N0} Brontobytes", bb) :
            //       yb > 1 ? string.Format(culture, "{0:N0} Yottabytes", yb) :
            //       zb > 1 ? string.Format(culture, "{0:N0} Zettabytes", zb) :
            //       eb > 1 ? string.Format(culture, "{0:N0} Exabytes", eb) :
            //       pb > 1 ? string.Format(culture, "{0:N0} Petabytes", pb) :
                   tb > 1 ? string.Format(culture, "{0:N2} Terabytes", tb) :
                   gb > 1 ? string.Format(culture, "{0:N2} Gigabytes", gb) :
                   mb > 1 ? string.Format(culture, "{0:N2} Megabytes", mb) :
                   kb > 1 ? string.Format(culture, "{0:N4} Kilobytes", kb) :
                   string.Format(culture, "{0} Bytes", bigUnSignedNumber);
        }

        public static string CalcMemoryMensurableUnit(string strUnSignedNumber)
        {
            double value;

            // Parse currency value using en-GB culture. 
            // value = "�1,097.63";
            // Displays:  
            //       Converted '�1,097.63' to 1097.63
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-US");

            return double.TryParse(strUnSignedNumber, style, culture, out value) 
                ? CalcMemoryMensurableUnit(value) 
                : string.Empty;
        }

        public static string CalcMemoryMensurableUnit(this long lngUnSignedNumber)
        {
            var bigInt = (double) lngUnSignedNumber;

            return CalcMemoryMensurableUnit(bigInt);
        }

        public static string CalcMemoryMensurableUnit(this int intUnSignedNumber)
        {
            var bigInt = (double)intUnSignedNumber;

            return CalcMemoryMensurableUnit(bigInt);
        }

        public static string GetExtension(this Image img)
        {
            var converter = new ImageFormatConverter();
            var extension = converter.ConvertToString(img.RawFormat);

            return extension?.ToLower();
        }
    }
}
