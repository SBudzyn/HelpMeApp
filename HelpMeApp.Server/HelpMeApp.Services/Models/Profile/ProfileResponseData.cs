using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Advert;

namespace HelpMeApp.Services.Models.Profile
{
    public class ProfileResponseData : ProfileDataBase
    {
        public IEnumerable<AdvertPreviewResponseData> UsersAdverts { get;set; }
    }
}
