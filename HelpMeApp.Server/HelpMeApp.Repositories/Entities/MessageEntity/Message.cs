using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Repositories.Entities.ChatterEntity;
using HelpMeApp.Repositories.Entities.SenderRoleEntity;

namespace HelpMeApp.Repositories.Entities.MessageEntity
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderRoleId { get; set; }
        public SenderRole SenderRole { get; set; } = null!;

        public int ChatterId { get; set; }
        public Chatter Chatter { get; set; } = null!;

        public string? Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
