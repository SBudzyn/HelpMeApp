using HelpMeApp.Services.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageData>> GetMessagesByChat(int ChatId);
        Task<MessageData> AddMessageAsync(MessageData messageData);
    }
}
