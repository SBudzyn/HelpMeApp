using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IChatWriteRepository
    {
        Task<Chat> AddChatAsync(Chat chat);
    }
}
