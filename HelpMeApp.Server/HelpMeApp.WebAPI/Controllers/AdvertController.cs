using FluentValidation;
using FluentValidation.Results;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Filters;
using HelpMeApp.WebAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private IValidator<AdvertPostData> _advertValidator;

        public AdvertController(IAdvertService advertService, IAuthorizationService authorizationService, IValidator<AdvertPostData> advertValidator)
        {
            _advertService = advertService;
            _authorizationService = authorizationService;
            _advertValidator = advertValidator;
        }

        [HttpGet("{pageId}")]
        public async Task<IActionResult> GetByPage([FromQuery] AdvertFiltersData filters, int page = 1, int pageSize = 20)
        {
            if (pageId < 1 || pageSize < 1)
            {
                return BadRequest();
            }

            return Ok(await _advertService.GetAdvertsByPage(filters, page, pageSize));
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
            ValidationResult validationResult = _advertValidator.Validate(advert);

            if (!validationResult.IsValid)
            {
                var modelStateDictionary = new ModelStateDictionary();

                foreach (ValidationFailure failure in validationResult.Errors.Distinct())
                {
                    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return ValidationProblem(modelStateDictionary);
            }

            var userId = Guid.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            var advertData = await _advertService.AddAdvertAsync(advert, userId);

            return CreatedAtAction(nameof(AddAdvert), advertData);
        }

        [Authorize]
        [HttpPut("{advertId}")]
        public async Task<IActionResult> UpdateAdvert(int advertId, AdvertPostData advert)
        {
            ValidationResult validationResult = _advertValidator.Validate(advert);

            if (!validationResult.IsValid)
            {
                var modelStateDictionary = new ModelStateDictionary();

                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return ValidationProblem(modelStateDictionary);
            }

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

        [HttpGet("general-data")]
        public async Task<IActionResult> GetGeneralData()
        {
            return Ok(await _advertService.GetGeneralDataAsync());
        }
    }
}
