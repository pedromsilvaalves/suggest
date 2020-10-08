using Suggest.Services.Models;

namespace Suggest.Services.Interfaces
{
    public interface ISuggestServices
    {
        CreateSuggestionReturnModel CreateSuggestion(string name, string email, string content);
    }
}
