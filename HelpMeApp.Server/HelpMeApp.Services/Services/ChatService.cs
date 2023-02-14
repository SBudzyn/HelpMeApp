using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Services
{
    public class ChatService : IChatService
    {
        private IChatReadRepository _chatReadRepository;
        private IChatWriteRepository _chatWriteRepository;
        private IMapper _mapper;

        public ChatService(IChatReadRepository chatReadRepository, IChatWriteRepository chatWriteRepository, IMapper mapper)
        {
            _chatReadRepository = chatReadRepository;
            _chatWriteRepository = chatWriteRepository;
            _mapper = mapper;
        }

        public async Task<ChatPreviewData> GetChatByIdAsync(int id)
        {
            var domainChat = await _chatReadRepository.GetChatByIdAsync(id);

            return _mapper.Map<ChatPreviewData>(domainChat);
        }

        public async Task<ChatPreviewData> GetChatByAdvertAndHelperAsync(int chatId, Guid helperId)
        {
            var domainChat = await _chatReadRepository.GetChatByAdvertAndHelperAsync(chatId, helperId);

            return _mapper.Map<ChatPreviewData>(domainChat);
        }

        public async Task<IEnumerable<ChatPreviewData>> GetChatsByUserAsync(Guid userId)
        {
            var domainChats = await _chatReadRepository.GetChatsByUserAsync(userId);

            return _mapper.Map<IEnumerable<ChatPreviewData>>(domainChats);
        }

        public async Task<ChatPreviewData> AddChatAsync(int advertId, Guid userId)
        {
            var chat = new Chat()
            {
                AdvertId = advertId,
                UserId = userId,
                IsConfirmedByCreator = false,
                IsConfirmedBySecondSide = false,
            };

            var domainChat = await _chatWriteRepository.AddChatAsync(chat);

            return _mapper.Map<ChatPreviewData>(domainChat);
        }
    }
}
