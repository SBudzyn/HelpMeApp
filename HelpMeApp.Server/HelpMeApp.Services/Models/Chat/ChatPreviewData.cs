using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
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
        public int AdvertId { get; set; }
        public string AdvertTitle { get; set; }
        public string AdvertPicture { get; set; }
        public Guid ResponderId { get; set; }
        public string ResponderName { get; set; }
        public string ResponderAvatar { get; set; }
        public MessageData LastMessage { get; set; }
    }
}
