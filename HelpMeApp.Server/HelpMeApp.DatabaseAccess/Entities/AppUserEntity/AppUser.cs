using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using Microsoft.AspNetCore.Identity;

namespace HelpMeApp.DatabaseAccess.Entities.AppUserEntity
{
    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public string PhotoPrefix { get; set; }
        public byte[] Photo { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
        public string Info { get; set; }
        [Required]
        public bool IsBlocked { get; set; }

        public List<Advert> Adverts { get; set; } = new List<Advert>();
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
