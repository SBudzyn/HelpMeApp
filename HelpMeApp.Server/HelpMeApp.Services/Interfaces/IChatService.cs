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
        Task<ChatPreviewData> GetChatByIdAsync(int id);
        Task<ChatPreviewData> GetChatByAdvertAndResponderAsync(int advertId, Guid helperId);
        Task<IEnumerable<ChatPreviewData>> GetChatsByUserAsync(Guid userId, int page, int pageSize);
        Task<ChatPreviewData> AddChatAsync(int advertId, Guid userId);
    }
}
