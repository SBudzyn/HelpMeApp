using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace HelpMeApp.DatabaseAccess.Entities.ChatEntity
{
    public class Chat
    {
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }

        [Required]
        public bool IsConfirmedByResponder { get; set; }
        [Required]
        public bool IsConfirmedByCreator { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
