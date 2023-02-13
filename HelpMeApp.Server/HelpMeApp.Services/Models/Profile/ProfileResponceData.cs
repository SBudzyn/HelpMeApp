using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Advert;

namespace HelpMeApp.Services.Models.Profile
{
    public class ProfileResponceData
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Info { get; set; }
        public bool IsBlocked { get; set; }
        public IEnumerable<AdvertPreviewResponseData> UsersAdverts { get;set; }
    }
}
