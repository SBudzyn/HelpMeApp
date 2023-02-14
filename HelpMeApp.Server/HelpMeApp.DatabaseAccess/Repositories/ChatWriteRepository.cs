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
        private HelpMeDbContext _context;
        private IChatReadRepository _chatReadRepository;

        public ChatWriteRepository(HelpMeDbContext context, IChatReadRepository chatReadRepository)
        {
            _context = context;
            _chatReadRepository = chatReadRepository;
        }

        public async Task<Chat> AddChatAsync(Chat chat)
        {
            var domainChat = await _context.AddAsync(chat);

            await _context.SaveChangesAsync();

            return await _chatReadRepository.GetChatByIdAsync(domainChat.Entity.Id);
        }
    }
}
