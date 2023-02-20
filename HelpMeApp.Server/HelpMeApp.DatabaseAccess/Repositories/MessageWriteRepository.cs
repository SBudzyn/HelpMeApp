using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class MessageWriteRepository : IMessageWriteRepository
    {
        private HelpMeDbContext _context;

        public MessageWriteRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<Message> AddMessageAsync(Message message)
        {
            var domainMessage = await _context.AddAsync(message);

            await _context.SaveChangesAsync();

            return domainMessage.Entity;
        }
    }
}
