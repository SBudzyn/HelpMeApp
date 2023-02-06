using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.DTO
{
    public class UserDateRespondDTO
    {
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public byte[] Photo { get; set; } = null;

        public DateTime RegistrationDate { get; set; } = DateTime.MinValue;

        public string Info { get; set; } = string.Empty;

        public bool IsBlocked { get; set; } = false;

        public List<Advert> Adverts { get; set; } = null;

        public List<Report> Reports { get; set; } = null;

        public List<Chat> Chats { get; set; } = null;

        public bool IsSuccessful { get; set; } = false;

        public string Message { get; set; } = string.Empty;
    }
}
