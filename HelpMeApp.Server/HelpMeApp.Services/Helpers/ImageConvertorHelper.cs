using System;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;

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

        public static string ConvertBase64ToString(Photo photo)
        {
            return string.Join(',', photo.Prefix, photo.Data);
        }
    }
}
