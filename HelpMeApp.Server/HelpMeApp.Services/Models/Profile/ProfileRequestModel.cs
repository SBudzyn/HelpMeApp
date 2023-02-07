
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Profile
{
    public class ProfileRequestModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Info { get; set; }
        public bool IsBlocked { get; set; }
        public List<HelpMeApp.DatabaseAccess.Entities.AdvertEntity.Advert> Adverts { get; set; }
        public List<Report> Reports { get; set; }
        public List<Chat> Chats { get; set; }
    }
}
