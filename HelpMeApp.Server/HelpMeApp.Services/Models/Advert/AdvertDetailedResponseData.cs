using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Advert
{
    public class AdvertDetailedResponseData : AdvertDataBase
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public Guid CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorPhoto { get; set; }
        public string Category { get; set; }
        public string Terms { get; set; }
        public List<string> Photos { get; set; } = new List<string>();
        public DateTime CreationDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
