using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Helpers
{
    public class ImageConvertorHelper
    {
        public static byte[] ConvertToBase64(string value)
        {
            string[] array = value.Split(",");

            return Convert.FromBase64String(array[1]);
        }

        public static string GetImagePrefix(string value)
        {
            return value.Split(",")[0];
        }
    }
}
