using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.WebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private IAdvertService _advertService;
        private IAuthorizationService _authorizationService;

        public AdvertController(IAdvertService advertService, IAuthorizationService authorizationService)
        {
            _advertService = advertService;
            _authorizationService = authorizationService;
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetByPage(string category, string location, string terms, string helpType, int page = 1, int pageSize = 20)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest();
            }

            return Ok(await _advertService.GetAdvertsByPage(category, location, terms, helpType, page, pageSize));
        }

        [HttpGet("{advertId}")]
        public async Task<IActionResult> GetById(int advertId)
        {
            if (advertId < 1)
            {
                return BadRequest();
            }

            var result = await _advertService.GetAdvertById(advertId);

            return result != null ? Ok(result) : NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAdvert(AdvertPostData advert)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            var advertData = await _advertService.AddAdvertAsync(advert, userId);

            return CreatedAtAction(nameof(AddAdvert), advertData);
        }

        [Authorize]
        [HttpPut("{advertId}")]
        public async Task<IActionResult> UpdateAdvert(int advertId, AdvertPostData advert)
        {
            if (await _advertService.GetAdvertById(advertId) == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, advertId, "EditPolicy");

            if (!authorizationResult.Succeeded)
            {
                return Unauthorized("You don`t have permission to modify the resource");
            }

            var result = await _advertService.UpdateAdvertAsync(advert, advertId);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{advertId}")]
        public async Task<IActionResult> DeactivateAdvert(int advertId)
        {
            if (await _advertService.GetAdvertById(advertId) == null)
            {
                return NotFound();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, advertId, "EditPolicy");

            if (!authorizationResult.Succeeded)
            {
                return Unauthorized("You don`t have permission to modify the resource");
            }

            var result = await _advertService.DeactivateAdvertAsync(advertId);

            return Ok(result);
        }
    }
}
