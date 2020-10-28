using Moq;
using Suggest.Infrastructure.Repositories;
using Suggest.Services.Entities;
using Suggest.Services.Enums;
using Suggest.Services.Models;
using Suggest.Services.Repositories;
using Suggest.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Suggest.Tests.Services
{
    public class SuggestServiceTest
    {
        [Theory]
        [InlineData("email@email.com", "Rogerio", "Isso e uma sugestao")]
        [InlineData("email2@email.com", "Reinaldo", "Isso e uma critica")]
        public void CreateSuggestion_Success(string email, string name, string content)
        {
            var suggestion = new Suggestion
            {
                Content = content,
                Name = name,
                Email = email
            };

            var repositoryMock = new Mock<ISuggestRepository>();
            repositoryMock.Setup(x => x.CreateSuggetion(It.IsAny<Suggestion>()))
                .Returns(suggestion);

            var suggestService = new SuggestService(repositoryMock.Object);
            var result = suggestService.CreateSuggestion(name, email, content);

            Assert.IsType<CreateSuggestionReturnModel>(result);
            Assert.IsType<Suggestion>(result.CreatedSuggestion);

            Assert.True(result.IsSuccessful);

            Assert.Equal(name, result.CreatedSuggestion.Name);
            Assert.Equal(email, result.CreatedSuggestion.Email);
            Assert.Equal(content, result.CreatedSuggestion.Content);
        }

        [Theory]
        [InlineData("", "Rogerio", "Isso e uma sugestao")]
        [InlineData("email2@email.com", "", "Isso e uma critica")]
        [InlineData("email2@email.com", "Reinaldo", "")]
        public void CreateSuggestion_ParamError(string email, string name, string content)
        {
            var repositoryMock = new Mock<ISuggestRepository>();
            repositoryMock.Setup(x => x.CreateSuggetion(It.IsAny<Suggestion>()))
                .Returns(new Suggestion());

            var suggestService = new SuggestService(repositoryMock.Object);
            var result = suggestService.CreateSuggestion(name, email, content);

            Assert.IsType<CreateSuggestionReturnModel>(result);
            Assert.False(result.IsSuccessful);
            Assert.Equal(ReturnErrorType.InvalidParameters, result.ErrorType);
        }
    }
}
