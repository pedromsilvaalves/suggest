using Suggest.Services.Entities;

namespace Suggest.Services.Models
{
    public class CreateSuggestionReturnModel : BaseReturnModel
    {
        Suggestion CreatedSuggestion { get; set; }
    }
}
