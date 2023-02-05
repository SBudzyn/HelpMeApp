using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertPreviewResponseData : AdvertBaseData
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
