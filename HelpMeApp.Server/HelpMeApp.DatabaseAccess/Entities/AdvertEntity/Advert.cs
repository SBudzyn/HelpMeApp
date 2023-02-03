using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Entities.TermsEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace HelpMeApp.DatabaseAccess.Entities.AdvertEntity
{
    public class Advert
    {
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        public Guid CreatorId { get; set; }
        public AppUser Creator { get; set; }

        [Required]
        public int HelpTypeId { get; set; }
        public HelpType HelpType { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int TermsId { get; set; }
        public Terms Terms { get; set; }

        public List<Photo> Photos { get; set; } = new List<Photo>();

        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? ClosureDate { get; set; }
        [Required]
        public bool IsClosed { get; set; }

        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
