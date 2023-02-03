using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
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

            return Ok(await _advertService.GetAdvertById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAdvert(AdvertPostData advert)
        {
            return await _advertService.AddAdvertAsync(advert) == true ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdvert(AdvertPostData advert)
        {
            return await _advertService.UpdateAdvertAsync(advert) == true ? Ok() : BadRequest();
        }
    }
}
