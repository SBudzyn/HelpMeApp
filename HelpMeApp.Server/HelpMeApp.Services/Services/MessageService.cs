using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Services
{
    public class MessageService : IMessageService
    {
        private IMessageReadRepository _messageReadRepository;
        private IMessageWriteRepository _messageWriteRepository;
        private IChatReadRepository _chatReadRepository;
        private IMapper _mapper;

        public MessageService(IMessageReadRepository messageReadRepository, IMessageWriteRepository messageWriteRepository, IChatReadRepository chatReadRepository, IMapper mapper)
        {
            _messageReadRepository = messageReadRepository;
            _messageWriteRepository = messageWriteRepository;
            _chatReadRepository = chatReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageData>> GetMessagesByChat(int chatId, int page = 1, int amount = 100)
        {
            var domainMessages = await _messageReadRepository.GetMessagesByChatAsync(chatId, page, amount);

            return _mapper.Map<IEnumerable<MessageData>>(domainMessages);
        }

        public async Task<MessageData> AddMessageAsync(MessageData messageData)
        {
            var message = _mapper.Map<Message>(messageData);
            
            var chat = await _chatReadRepository.GetChatByIdAsync(messageData.ChatId);  

            if (chat.Advert.CreatorId == messageData.SenderId)
            {
                message.SenderRoleId = 1;
            }
            else if (chat.UserId == messageData.SenderId)
            {
                message.SenderRoleId = 2;
            }
            else
            {
                message.SenderRoleId = 3;
            }

            var domainMessage = await _messageWriteRepository.AddMessageAsync(message);

            var messageToReturn = _mapper.Map<MessageData>(domainMessage);

            if (domainMessage.SenderRoleId == 1)
            {
                messageToReturn.SenderId = domainMessage.Chat.Advert.CreatorId;
            }
            else if (domainMessage.SenderRoleId == 2)
            {
                messageToReturn.SenderId = domainMessage.Chat.UserId;
            }

            return messageToReturn;
        }
    }
}
