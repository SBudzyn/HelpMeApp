﻿using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Advert;
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
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            try
            {
                return Ok(await _advertService.UpdateAdvertAsync(advert, advertId, userId));
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{advertId}")]
        public async Task<IActionResult> DeactivateAdvert(int advertId)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            try
            {
                return Ok(await _advertService.DeactivateAdvertAsync(advertId, userId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
