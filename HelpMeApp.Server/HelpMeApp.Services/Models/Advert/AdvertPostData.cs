using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertPostData : AdvertBaseData
    {
        public string Info { get; set; }
        public int CategoryId { get; set; }
        public int TermsId { get; set; }
        public int HelpTypeId { get; set; }
        public List<byte[]> Photos { get; set; } = new List<byte[]>();
    }
}
