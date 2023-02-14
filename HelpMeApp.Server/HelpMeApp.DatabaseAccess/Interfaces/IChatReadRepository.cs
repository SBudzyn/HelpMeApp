using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IChatReadRepository
    {
        Task<Chat> GetChatByIdAsync(int id);
        Task<IEnumerable<Chat>> GetChatsByUserAsync(Guid userId);
        Task<Chat> GetChatByAdvertAndHelperAsync(int advertId, Guid userId);
    }
}
