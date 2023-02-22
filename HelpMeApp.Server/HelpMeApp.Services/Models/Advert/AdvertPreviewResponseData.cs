using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertPreviewResponseData : AdvertDataBase
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
