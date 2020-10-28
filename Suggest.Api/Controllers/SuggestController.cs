using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suggest.Api.Models;
using Suggest.Services.Entities;
using Suggest.Services.Interfaces;
using Suggest.Services.Models;
using Suggest.Services.Repositories;
using System;

namespace Suggest.Api.Controllers
{
    [ApiController]
    [Route("suggestions")]
    public class SuggestController : ApiBaseController
    {
        private readonly ISuggestRepository _suggestRepository;
        private readonly ISuggestService _suggestServices;
        public SuggestController(ISuggestRepository suggestRepository, ISuggestService suggestService)
        {
            _suggestRepository = suggestRepository;
            _suggestServices = suggestService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Suggestion[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [Route("")]
        public IActionResult GetSuggestions()
        {
            var suggestions = _suggestRepository.GetSuggestions();
            return Ok(suggestions);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Suggestion[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [Route("{suggestionId}")]
        public IActionResult GetSuggestion([FromRoute]Guid suggestionId)
        {
            var suggestion = _suggestRepository.GetSuggestion(suggestionId);
            if(suggestion == null)
            {
                return NotFound("Suggestion not found");
            }
            return Ok(suggestion);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateSuggestion([FromBody] CreateSuggestionInputModel createSuggestionModel)
        {
            var createdSuggestionReturnModel = _suggestServices.CreateSuggestion(createSuggestionModel.Name, createSuggestionModel.Email, createSuggestionModel.Content);
            if (createdSuggestionReturnModel.IsSuccessful && createdSuggestionReturnModel.CreatedSuggestion != null)
            {
                return Ok(createdSuggestionReturnModel.CreatedSuggestion);
            }
            return BadRequest("Invalid parameters");
        }
    }
}
