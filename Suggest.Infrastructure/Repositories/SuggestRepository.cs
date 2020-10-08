using Suggest.Infrastructure.Models;
using Suggest.Services.Entities;
using Suggest.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Suggest.Infrastructure.Repositories
{
    public class SuggestRepository : ISuggestRepository
    {
        private readonly SuggestionContext _suggestionContext;
        public SuggestRepository(SuggestionContext suggestionContext)
        {
            _suggestionContext = suggestionContext;
        }

        public IEnumerable<Suggestion> GetSuggestions()
        {
            return _suggestionContext.Suggestions
                        .Select(x => x)
                        .ToList();
        }

        public Suggestion GetSuggestion(Guid suggestionId)
        {
            return _suggestionContext.Find<Suggestion>(suggestionId);
        }

        public Suggestion CreateSuggetion(Suggestion newSuggestion)
        {
            return null;
        }
    }
}
