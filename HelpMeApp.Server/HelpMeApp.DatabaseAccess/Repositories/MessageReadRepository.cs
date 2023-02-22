using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class MessageReadRepository : IMessageReadRepository
    {
        private HelpMeDbContext _context;

        public MessageReadRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatAsync(int chatId, int page, int amount)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId)
                .Include(m => m.Chat)
                .ThenInclude(c => c.Advert)
                .OrderBy(c => c.CreationDate)
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToListAsync();
        }
    }
}
