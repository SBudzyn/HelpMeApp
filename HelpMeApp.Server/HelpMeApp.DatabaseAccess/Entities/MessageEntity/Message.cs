using System;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity;

namespace HelpMeApp.DatabaseAccess.Entities.MessageEntity
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int SenderRoleId { get; set; }
        public SenderRole SenderRole { get; set; }

        [Required]
        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
