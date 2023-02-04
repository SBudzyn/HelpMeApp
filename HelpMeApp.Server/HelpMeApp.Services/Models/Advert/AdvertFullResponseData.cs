using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertFullResponseData
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Info { get; set; }
        public string Location { get; set; }
        public Guid CreatorId { get; set; }
        public string Category { get; set; }
        public string Terms { get; set; }
        public List<byte[]> Photos { get; set; } = new List<byte[]>();
        public DateTime CreationDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
