using HelpMeApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/chats")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private IChatService _chatService;
        private IAdvertService _advertService;
        private IMessageService _messageService;

        public ChatsController(IChatService chatService, IAdvertService advertService, IMessageService messageService)
        {
            _chatService = chatService;
            _advertService = advertService;
            _messageService = messageService;
        }

        [Authorize]
        [HttpGet("get-my-chats")]
        public async Task<IActionResult> GetMyChats(int page = 1, int pageSize = 30)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            return Ok(await _chatService.GetChatsByUserAsync(userId, page, pageSize));
        }

        [Authorize]
        [HttpGet("advert/{advertId}")]
        public async Task<IActionResult> GetChatByAdvert(int advertId)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            var chat = await _chatService.GetChatByAdvertAndResponderAsync(advertId, userId);

            if (chat != null)
            {
                return Ok(chat);
            }

            var advert = await _advertService.GetAdvertByIdAsync(advertId);

            if (advert == null)
            {
                return BadRequest();
            }

            var createdChat = await _chatService.AddChatAsync(advertId, userId);

            return Ok(createdChat);
        }

        [Authorize]
        [HttpGet("messages/{chatId}")]
        public async Task<IActionResult> GetMessagesByChat(int chatId, int page = 1, int amount = 100)
        {
            return Ok(await _messageService.GetMessagesByChat(chatId, page, amount));
        }
    }
}
