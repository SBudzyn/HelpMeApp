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

        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.All.SendAsync("Bomba");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (_connections.ContainsKey(Context.ConnectionId))
            {
                _connections.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);

        }

        public async Task Test()
        {
            await Clients.All.SendAsync("Hiiiiii");
        }

        public async Task JoinChat(int advertId)
        {
            var userId = Guid.Parse(Context.User.Claims.First(c => c.Type == "UserId").Value);

            var chatId = await _chatService.GetChatIdAsync(userId, advertId);

            _connections[Context.ConnectionId] = new UserConnection() { ChatId = chatId.ToString() };
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());

            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                var messageHistory = _messageService.GetMessagesByChat(chatId);

                await Clients.Group(userConnection.ChatId).SendAsync("Receive", messageHistory);
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

                await Clients.Group(userConnection.ChatId).SendAsync("Receive", savedMessage);
            }

        }
    }
}
