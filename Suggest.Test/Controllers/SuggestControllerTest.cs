using Microsoft.AspNetCore.Mvc;
using Moq;
using Suggest.Api.Controllers;
using Suggest.Api.Models;
using Suggest.Services.Entities;
using Suggest.Services.Interfaces;
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
            var suggestService = new Mock<ISuggestServices>();

            suggestRepository.Setup(x => x.GetSuggestions()).Returns(new List<Suggestion>());
            
            var result = new SuggestController(suggestRepository.Object, suggestService.Object).GetSuggestions();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetSuggestion_NotFound_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            suggestRepository.Setup(x => x.GetSuggestion(It.IsAny<Guid>())).Returns((Suggestion)null);

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).GetSuggestion(new Guid());
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetSuggestion_Success_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            suggestRepository.Setup(x => x.GetSuggestion(It.IsAny<Guid>())).Returns(new Suggestion());

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).GetSuggestion(new Guid());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_Null_BadRequest_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_InvalidName_BadRequest_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            var createSuggestionInputModel = new CreateSuggestionInputModel
            {
                Name = null,
                Content = "Test content",
                Email = "test@test.com"
            };

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(createSuggestionInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_InvalidContent_BadRequest_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            var createSuggestionInputModel = new CreateSuggestionInputModel
            {
                Name = "Persona Test",
                Content = null,
                Email = "test@test.com"
            };

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(createSuggestionInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_InvalidEmail_BadRequest_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            var createSuggestionInputModel = new CreateSuggestionInputModel
            {
                Name = "Persona Test",
                Content = "Test content",
                Email = null
            };

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(createSuggestionInputModel);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateSuggestion_Success_Test()
        {
            var suggestRepository = new Mock<ISuggestRepository>();
            var suggestService = new Mock<ISuggestServices>();

            var createSuggestionInputModel = new CreateSuggestionInputModel
            {
                Name = "Persona Name",
                Content = "Test content",
                Email = "test@test.com"
            };

            var result = new SuggestController(suggestRepository.Object, suggestService.Object).CreateSuggestion(createSuggestionInputModel);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
