using System;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;

namespace HelpMeApp.DatabaseAccess.Entities.PhotoEntity
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }

        public string Prefix { get; set; }
        [Required]
        public byte[] Data { get; set; }
    }
}