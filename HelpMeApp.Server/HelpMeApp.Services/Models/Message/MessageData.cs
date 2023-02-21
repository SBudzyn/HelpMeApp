using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Message
{
    public class MessageData
    {
        public Guid SenderId { get; set; }
        public string Text { get; set; }
        public int ChatId { get; set; }
        public DateTime SentTime { get; set; }
    }
}
