using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;

namespace HelpMeApp.DatabaseAccess.Entities.ChatEntity
{
    public class Chat
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public int AdvertId { get; set; }
        public Advert Advert { get; set; } = null!;

        public bool IsConfirmedBySecondSide { get; set; }
        public bool IsConfirmedByCreator { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
