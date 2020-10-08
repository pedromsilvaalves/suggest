using Suggest.Services.Enums;

namespace Suggest.Services.Models
{
    public class BaseReturnModel
    {
        public bool IsSuccessful { get; set; }
        public ReturnErrorType ErrorType { get; set; }
    }
}
