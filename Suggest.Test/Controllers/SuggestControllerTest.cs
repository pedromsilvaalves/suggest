using Microsoft.AspNetCore.Mvc;
using Moq;
using Suggest.Api.Controllers;
using Suggest.Services.Entities;
using Suggest.Services.Repositories;
using System.Collections.Generic;
using Xunit;

namespace Suggest.Tests.Controllers
{
    public class SuggestControllerTest
    {
        [Fact]
        public void GetSuggestions_Sucess_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            suggestRepository.Setup(x => x.GetSuggestions()).Returns(new List<Suggestion>());

            var result = new SuggestController(suggestRepository.Object).GetSuggestions();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetSuggestion_NotFound_Test()
        {

        }
    }
}
