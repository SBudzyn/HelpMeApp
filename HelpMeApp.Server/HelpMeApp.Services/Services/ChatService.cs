using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Helpers;
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

        public async Task<ChatPreviewData> GetChatByAdvertAndResponderAsync(int chatId, Guid helperId)
        {
            var domainChat = await _chatReadRepository.GetChatByAdvertAndResponderAsync(chatId, helperId);

            return _mapper.Map<ChatPreviewData>(domainChat);
        }

        public async Task<IEnumerable<ChatPreviewData>> GetChatsByUserAsync(Guid userId, int page, int pageSize)
        {
            var domainChats = await _chatReadRepository.GetChatsByUserAsync(userId, page, pageSize);

            var mappedChats = new List<ChatPreviewData>();

            foreach (var chat in domainChats)
            {
                var chatData = _mapper.Map<ChatPreviewData>(chat);

                if (chat.UserId == userId)
                {
                    chatData.ResponderName = chat.Advert.Creator.Name;
                    chatData.ResponderId = chat.Advert.CreatorId;
                    chatData.ResponderAvatar = ImageConvertorHelper.ConvertPhotoToString(chat.Advert.Creator.PhotoPrefix, chat.Advert.Creator.Photo);
                }
                else
                {
                    chatData.ResponderName = chat.User.Name;
                    chatData.ResponderId = chat.UserId;
                    chatData.ResponderAvatar = ImageConvertorHelper.ConvertPhotoToString(chat.User.PhotoPrefix, chat.User.Photo);
                }

                chatData.AdvertPicture = ImageConvertorHelper.ConvertPhotoToString(chat.Advert.Photos.FirstOrDefault());

                mappedChats.Add(chatData);
            }

            return mappedChats;
        }

        public async Task<ChatPreviewData> AddChatAsync(int advertId, Guid userId)
        {
            var chat = new Chat()
            {
                AdvertId = advertId,
                UserId = userId,
                IsConfirmedByCreator = false,
                IsConfirmedByResponder = false,
            };

            var domainChat = await _chatWriteRepository.AddChatAsync(chat);

            return _mapper.Map<ChatPreviewData>(domainChat);
        }
    }
}
