using HelpMeApp.Services.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Chat
{
    public class ChatPreviewData
    {
        public int Id { get; set; }
        public string AdvertTitle { get; set; }
        public byte[] AdvertPhoto { get; set; }
        public string InterlocutorName { get; set; }
        public MessageData LastMessage { get; set; }
    }
}
