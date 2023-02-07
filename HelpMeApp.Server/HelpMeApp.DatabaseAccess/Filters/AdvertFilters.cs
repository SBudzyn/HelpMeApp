using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Filters
{
    public class AdvertFilters
    {
        public int HelpTypeId { get; set; }
        public int CategoryId { get; set; }
        public int TermsId { get; set; }
        public string Location { get; set; }
        public string SortBy { get; set; }
    }
}
