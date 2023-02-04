using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertPostData
    {
        public string Header { get; set; }
        public string Info { get; set; }
        public string Location { get; set; }
        public Guid CreatorId { get; set; }
        public int CategoryId { get; set; }
        public int TermsId { get; set; }
        public int HelpTypeId { get; set; }
        public List<byte[]> Photos { get; set; } = new List<byte[]>();
    }
}
