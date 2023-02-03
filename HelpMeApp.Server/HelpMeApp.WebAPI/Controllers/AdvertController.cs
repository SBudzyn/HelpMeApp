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
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private IAdvertService _advertService;
        private ILogger<AdvertController> _logger;

        public AdvertController(IAdvertService advertService, ILogger<AdvertController> logger)
        {
            _advertService = advertService;
            _logger = logger;
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
            try
            {
                var advertData = await _advertService.AddAdvertAsync(advert);

                return Ok(advertData);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);

                return BadRequest();
            }
        }
    }
}
