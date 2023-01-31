using System;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;

namespace HelpMeApp.DatabaseAccess.Entities.ReportEntity
{
    public class Report
    {
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }

        public string Text { get; set; }
    }
}
