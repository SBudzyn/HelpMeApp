using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;

namespace HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity
{
    public class SenderRole
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}