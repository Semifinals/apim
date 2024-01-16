using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Semifinals.Filters;

public class AuthorizeTrigger
{
    [Authorize]
    [FunctionName(nameof(AuthorizeTrigger))]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
    {
        return new OkObjectResult("Authorize succeeded");
    }
}
