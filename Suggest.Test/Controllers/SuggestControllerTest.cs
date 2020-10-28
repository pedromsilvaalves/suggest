using Microsoft.AspNetCore.Mvc;
using Moq;
using Suggest.Api.Controllers;
using Suggest.Api.Models;
using Suggest.Services.Entities;
using Suggest.Services.Interfaces;
using Suggest.Services.Models;
using Suggest.Services.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace Suggest.Tests.Controllers
{
    public class SuggestControllerTest
    {
        [Fact]
        public void GetSuggestions_Success_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestService>();

            suggestRepository.Setup(x => x.GetSuggestions()).Returns(new List<Suggestion>());
            
            var result = new SuggestController(suggestRepository.Object, suggestService.Object).GetSuggestions();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetSuggestion_NotFound_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestService>();

            suggestRepository.Setup(x => x.GetSuggestion(It.IsAny<Guid>())).Returns((Suggestion)null);

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).GetSuggestion(new Guid());
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetSuggestion_Success_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestService>();

            suggestRepository.Setup(x => x.GetSuggestion(It.IsAny<Guid>())).Returns(new Suggestion());

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).GetSuggestion(new Guid());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_InvalidParameter_BadRequest_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestService>();

            var createSuggestionReturn = new CreateSuggestionReturnModel
            {
                CreatedSuggestion = new Suggestion(),
                ErrorType = Suggest.Services.Enums.ReturnErrorType.InvalidParameters,
                IsSuccessful = false
            };

            var createSuggestionInputModel = new CreateSuggestionInputModel
            {
                Name = null,
                Content = "Test content",
                Email = "test@test.com"
            };

            suggestService.Setup(x => x.CreateSuggestion(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(createSuggestionReturn);

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(createSuggestionInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_Success_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestService>();

            var createSuggestionReturn = new CreateSuggestionReturnModel
            {
                CreatedSuggestion = new Suggestion(),
                IsSuccessful = true
            };

            var createSuggestionInputModel = new CreateSuggestionInputModel
            {
                Name = "Persona Name",
                Content = "Test content",
                Email = "test@test.com"
            };

            suggestService.Setup(x => x.CreateSuggestion(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(createSuggestionReturn);

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(createSuggestionInputModel);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
