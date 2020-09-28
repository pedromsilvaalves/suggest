using Microsoft.AspNetCore.Mvc;
using Suggest.Services.Models;

namespace Suggest.Api.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(string message)
        {
            return new BadRequestObjectResult(new ErrorModel(message));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }
    }
}