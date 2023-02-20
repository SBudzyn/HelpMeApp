using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IMessageWriteRepository
    {
        Task<Message> AddMessageAsync(Message message);
    }
}
