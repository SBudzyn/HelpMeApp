using HelpMeApp.Services.Models.Advert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Profile
{
    public class ProfileResponseData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Info { get; set; }
        public bool IsBlocked { get; set; }
        public int UserHelpCount { get; set; }
    }
}
