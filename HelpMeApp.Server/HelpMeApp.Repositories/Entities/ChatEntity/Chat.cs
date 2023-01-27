using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Entities.UserEntity;

namespace HelpMeApp.DatabaseAccess.Entities.ChatEntity
{
    public class Chat
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int AdvertId { get; set; }
        public Advert Advert { get; set; } = null!;

        public bool IsConfirmedBySecondSide { get; set; }
        public bool IsConfirmedByCreator { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
