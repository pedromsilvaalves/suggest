using Suggest.Services.Entities;
using Suggest.Services.Interfaces;
using Suggest.Services.Models;
using Suggest.Services.Repositories;
using System;

namespace Suggest.Services.Services
{
    public class SuggestService : ISuggestService
    {
        private readonly ISuggestRepository _suggestRepository;
        public SuggestService(ISuggestRepository suggestRepository)
        {
            _suggestRepository = suggestRepository;
        }

        public CreateSuggestionReturnModel CreateSuggestion(string name, string email, string content)
        {
            var result = new CreateSuggestionReturnModel()
            {
                IsSuccessful = false
            };

            if (!IsValid(name, email, content))
            {
                result.ErrorType = Enums.ReturnErrorType.InvalidParameters;
                return result;
            }

            var newSuggestion = new Suggestion()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Name = name,
                Content = content
            };

            result.CreatedSuggestion = _suggestRepository.CreateSuggetion(newSuggestion);
            result.IsSuccessful = true;

            return result;
        }

        private bool IsValid(string name, string email, string content)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(content))
                return false;
            return true;
        }
    }
}
