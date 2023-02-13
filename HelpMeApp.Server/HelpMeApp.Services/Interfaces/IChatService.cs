using HelpMeApp.Services.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatPreviewData>> GetChatsByUserAsync(Guid userId);
        Task<int> GetChatIdAsync(Guid userId, int advertId);
    }
}
