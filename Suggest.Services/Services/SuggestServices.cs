using Suggest.Services.Interfaces;
using Suggest.Services.Models;
using Suggest.Services.Repositories;

namespace Suggest.Services.Services
{
    public class SuggestServices : ISuggestServices
    {
        private readonly ISuggestRepository _suggestRepository;
        public SuggestServices(ISuggestRepository suggestRepository)
        {
            _suggestRepository = suggestRepository;
        }

        public CreateSuggestionReturnModel CreateSuggestion(string name, string email, string content)
        {
            throw new System.NotImplementedException();
        }
    }
}
