using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IMessageReadRepository
    {
        Task<Message> GetMessageByIdAsync(int id);
        Task<IEnumerable<Message>> GetMessagesByChatAsync(int chatId, int page, int amount);
    }
}
