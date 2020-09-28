using Suggest.Services.Entities;
using Suggest.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suggest.Infrastructure.Repositories
{
    public class SuggestRepository : ISuggestRepository
    {
        public IEnumerable<Suggestion> GetSuggestions()
        {
            return new Suggestion[] { new Suggestion()};
        }
    }
}
