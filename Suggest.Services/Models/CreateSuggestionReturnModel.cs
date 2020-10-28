using Suggest.Services.Entities;

namespace Suggest.Services.Models
{
    public class CreateSuggestionReturnModel : BaseReturnModel
    {
        public Suggestion CreatedSuggestion { get; set; }
    }
}
