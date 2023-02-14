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

        public ChatsController(IChatService chatService, IAdvertService advertService)
        {
            _chatService = chatService;
            _advertService = advertService;
        }

        [Authorize]
        [HttpGet("get-my-chats")]
        public async Task<IActionResult> GetMyChats()
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            return Ok(await _chatService.GetChatsByUserAsync(userId));
        }

        [Authorize]
        [HttpGet("advert/{advertId}")]
        public async Task<IActionResult> GetChatByAdvert(int advertId)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            var chat = await _chatService.GetChatByAdvertAndHelperAsync(advertId, userId);

            if (chat != null)
            {
                return Ok(chat);
            }

            var advert = await _advertService.GetAdvertById(advertId);

            if (advert == null)
            {
                return BadRequest();
            }

            var createdChat = await _chatService.AddChatAsync(advertId, userId);

            return Ok(createdChat);
        }
    }
}
