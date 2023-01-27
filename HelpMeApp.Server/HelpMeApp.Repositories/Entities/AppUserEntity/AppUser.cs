using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using Microsoft.AspNetCore.Identity;

namespace HelpMeApp.DatabaseAccess.Entities.AppUserEntity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? Phone { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? Info { get; set; }
        public bool IsBlocked { get; set; }

        public List<Advert> Adverts { get; set; } = new List<Advert>();
        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
