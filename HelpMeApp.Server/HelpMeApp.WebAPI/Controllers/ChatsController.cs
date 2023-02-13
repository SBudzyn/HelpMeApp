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

        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [Authorize]
        [HttpGet("get-my-chats")]
        public async Task<IActionResult> GetMyChats()
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            return Ok(await _chatService.GetChatsByUserAsync(userId));
        }
    }
}
