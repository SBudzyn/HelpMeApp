using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class ChatReadRepository : IChatReadRepository
    {
        private HelpMeDbContext _context;

        public ChatReadRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<Chat> GetChatByIdAsync(int id)
        {
            return await _context.Chats
                .Include(c => c.Advert)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Chat>> GetChatsByUserAsync(Guid userId, int page, int pageSize)
        {
            return await _context.Chats
                .Where(c => c.UserId == userId || c.Advert.CreatorId == userId)
                .Include(c => c.User)
                .Include(c => c.Advert)
                .ThenInclude(a => a.Creator)
                .Include(c => c.Advert)
                .ThenInclude(a => a.Photos)
                .Include(c => c.Messages)
                .OrderByDescending(c => c.Messages.OrderByDescending(c => c.CreationDate).FirstOrDefault().CreationDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Chat> GetChatByAdvertAndResponderAsync(int advertId, Guid userId)
        {
            return await _context.Chats
                .Where(c => c.UserId == userId)
                .Where(c => c.AdvertId == advertId)
                .Include(c => c.User)
                .Include(c => c.Advert)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync();
        }
    }
}
