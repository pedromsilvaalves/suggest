using Suggest.Services.Models;

namespace Suggest.Services.Interfaces
{
    public interface ISuggestService
    {
        CreateSuggestionReturnModel CreateSuggestion(string name, string email, string content);
    }
}
