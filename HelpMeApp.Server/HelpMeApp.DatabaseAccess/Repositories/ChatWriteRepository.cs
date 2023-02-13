using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class ChatWriteRepository : IChatWriteRepository
    {
        HelpMeDbContext _context;

        public ChatWriteRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<Chat> AddChatAsync(Chat chat)
        {
            var domainAdvert = await _context.AddAsync(chat);

            await _context.SaveChangesAsync();

            return domainAdvert.Entity;
        }
    }
}
