using System;
using Bogus.DataSets;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;

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

        public static string ConvertPhotoToString(Photo photo)
        {
            if (string.IsNullOrEmpty(photo?.Prefix))
            {
                return string.Empty;
            }

            return string.Join(',', photo.Prefix, Convert.ToBase64String(photo.Data));
        }

        public static string ConvertPhotoToString(string prefix, byte[] data)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return string.Empty;
            }

            return string.Join(',', prefix, Convert.ToBase64String(data));
        }
    }
}
