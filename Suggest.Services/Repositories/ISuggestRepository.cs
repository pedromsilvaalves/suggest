using Suggest.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suggest.Services.Repositories
{
    public interface ISuggestRepository
    {
        IEnumerable<Suggestion> GetSuggestions();
        Suggestion GetSuggestion(Guid suggestionId);
    }
}
