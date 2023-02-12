using System;

namespace HelpMeApp.Services.Helpers
{
    public class ImageConvertorHelper
    {
        public static byte[] ConvertToBase64(string value)
        {
            if (string.IsNullOrEmpty(value)) 
            {
            return Array.Empty<byte>();
            }

            string[] array = value.Split(",");

            return Convert.FromBase64String(array[1]);
        }

        public static string GetImagePrefix(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.Split(",")[0];
        }
    }
}
