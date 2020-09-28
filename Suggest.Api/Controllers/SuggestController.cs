using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suggest.Services.Entities;
using Suggest.Services.Models;
using Suggest.Services.Repositories;
using System;

namespace Suggest.Api.Controllers
{
    [ApiController]
    [Route("suggest")]
    public class SuggestController : ApiBaseController
    {
        private ISuggestRepository _suggestRepository;
        public SuggestController(ISuggestRepository suggestRepository)
        {
            _suggestRepository = suggestRepository;
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
        public IActionResult GetSuggestions([FromRoute]Guid suggestionId)
        {
            return Ok("");
        }
    }
}
