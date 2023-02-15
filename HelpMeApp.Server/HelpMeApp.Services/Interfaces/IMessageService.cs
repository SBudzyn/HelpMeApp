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
        Task<IEnumerable<MessageData>> GetMessagesByChat(int chatId, int page = 1, int amount = 100);
        Task<MessageData> AddMessageAsync(MessageData messageData);
    }
}
