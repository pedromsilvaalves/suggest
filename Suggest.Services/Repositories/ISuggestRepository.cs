using Suggest.Services.Entities;
using System;
using System.Collections.Generic;

namespace Suggest.Services.Repositories
{
    public interface ISuggestRepository
    {
        IEnumerable<Suggestion> GetSuggestions();
        Suggestion GetSuggestion(Guid suggestionId);
    }
}
