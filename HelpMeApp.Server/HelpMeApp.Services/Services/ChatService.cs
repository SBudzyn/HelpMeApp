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


        public async Task<IEnumerable<ChatPreviewData>> GetChatsByUserAsync(Guid userId)
        {
            var domainChats = await _chatReadRepository.GetChatsByUserAsync(userId);

            return _mapper.Map<IEnumerable<ChatPreviewData>>(domainChats);
        }

        public async Task<int> GetChatIdAsync(Guid userId, int advertId)
        {
            var domainChat = await _chatReadRepository.GetCertainChatAsync(userId, advertId);

            if (domainChat == null)
            {
                var chat = new Chat();

                chat.AdvertId = advertId;
                chat.UserId = userId;
                chat.IsConfirmedByCreator = false;
                chat.IsConfirmedBySecondSide = false;

                var createdAdvert =  await _chatWriteRepository.AddChatAsync(chat);

                return createdAdvert.Id;
            }

            return domainChat.Id;
        }
    }
}
