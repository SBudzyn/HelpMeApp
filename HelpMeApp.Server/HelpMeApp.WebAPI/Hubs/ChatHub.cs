using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models;
using HelpMeApp.Services.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private IChatService _chatService;
        private IMessageService _messageService;
        private IDictionary<string, UserConnection> _connections;

        public ChatHub(IChatService chatService, IMessageService messageService, IDictionary<string, UserConnection> connections)
        {
            _chatService = chatService;
            _messageService = messageService;
            _connections = connections;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.ContainsKey(Context.ConnectionId))
            {
                _connections.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);

        }

        public async Task JoinChat(int chatId)
        {
            var userId = Guid.Parse(Context.User.Claims.First(c => c.Type == "UserId").Value);

            var chat = await _chatService.GetChatByIdAsync(chatId);

            if (chat == null)
            {
                return;
            }

            _connections[Context.ConnectionId] = new UserConnection() { ChatId = chatId.ToString() };
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());

            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                var messageHistory = await  _messageService.GetMessagesByChat(chatId);

                await Clients.Group(userConnection.ChatId).SendAsync("ReceiveMessagesHistory", messageHistory);
            }
        }

        public async Task SendMessage(string message)
        {
            var senderId = Guid.Parse(Context.User.Claims.First(c => c.Type == "UserId").Value);

            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                var messageData = new MessageData()
                {
                    ChatId = int.Parse(userConnection.ChatId),
                    SenderId = senderId,
                    SentTime = DateTime.Now,
                    Text = message
                };

                var savedMessage = await _messageService.AddMessageAsync(messageData);

                await Clients.Group(userConnection.ChatId).SendAsync("ReceiveMessage", savedMessage);
            }

        }
    }
}
