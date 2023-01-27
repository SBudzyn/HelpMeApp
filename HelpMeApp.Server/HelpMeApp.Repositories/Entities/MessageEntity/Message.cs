using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity;

namespace HelpMeApp.DatabaseAccess.Entities.MessageEntity
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderRoleId { get; set; }
        public SenderRole SenderRole { get; set; } = null!;

        public int ChatId { get; set; }
        public Chat Chat { get; set; } = null!;

        public string Text { get; set; } = null!;
        public DateTime CreationDate { get; set; }
    }
}
