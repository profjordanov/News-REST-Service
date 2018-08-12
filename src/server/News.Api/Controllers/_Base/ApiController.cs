using Microsoft.AspNetCore.Mvc;
using News.Core;

namespace News.Api.Controllers._Base
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        protected IActionResult Error(Error error) =>
            new BadRequestObjectResult(error);

        protected IActionResult Success(Success success) =>
            new OkObjectResult(success);
    }
}
