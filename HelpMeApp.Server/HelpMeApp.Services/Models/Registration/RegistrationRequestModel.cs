using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Registration
{
    public class RegistrationRequestModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
  
        public byte[] Photo { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.MinValue;

        public string Info { get; set; } = string.Empty;

        public bool IsBlocked { get; set; } = false;

        public List<HelpMeApp.DatabaseAccess.Entities.AdvertEntity.Advert> Adverts { get; set; } = null;

        public List<Report> Reports { get; set; } = null;

        public List<Chat> Chats { get; set; } = null;
    }
}
