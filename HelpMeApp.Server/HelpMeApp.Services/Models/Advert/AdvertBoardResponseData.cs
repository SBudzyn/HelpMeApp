using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertBoardResponseData
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Location { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
