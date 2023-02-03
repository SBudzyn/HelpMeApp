using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;

namespace HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity
{
    public class HelpType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Advert> Adverts { get; set; } = new List<Advert>();
    }
}