using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Entities.TermsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models
{
    public class GeneralData
    {
        public int AdvertsQuantity { get; set; }
        public Dictionary<int, string> Categories { get; set; }
        public Dictionary<int, string> Terms { get; set; }
        public Dictionary<int, string> HelpTypes { get; set; }
    }
}
