using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Filters
{
    public class AdvertFiltersData
    {
        public int HelpTypeId { get; set; }
        public int CategoryId { get; set; }
        public int TermsId { get; set; }
        public string Location { get; set; }
        public string SortBy { get; set; }
    }
}
