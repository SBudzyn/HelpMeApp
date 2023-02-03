using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetByPage(int page = 1, int pageSize = 20)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest();
            }

            return Ok(await _advertService.GetAdvertsByPage(page, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var result = await _advertService.GetAdvertById(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdvert(AdvertPostData advert)
        {
            var advertData = await _advertService.AddAdvertAsync(advert);

            return CreatedAtAction(nameof(AddAdvert), advertData);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeactivateAdvert(int id)
        {
            return await _advertService.DeactivateAdvertAsync(id) == true ? NoContent() : BadRequest();
        }
    }
}
