using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Entities.TermsEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;

namespace HelpMeApp.DatabaseAccess.Entities.AdvertEntity
{
    public class Advert
    {
        public int Id { get; set; }
        public string Header { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Location { get; set; } = null!;

        public Guid CreatorId { get; set; }
        public AppUser Creator { get; set; } = null!;

        public int HelpTypeId { get; set; }
        public HelpType HelpType { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int TermsId { get; set; }
        public Terms Terms { get; set; } = null!;

        public List<Photo> Photos { get; set; } = new List<Photo>();

        public DateTime CreationDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public bool? IsActive { get; set; }

        public List<Report> Reports { get; set; } = new List<Report>();
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
