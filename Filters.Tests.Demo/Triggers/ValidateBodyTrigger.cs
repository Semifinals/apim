using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Semifinals.Filters;

public class ValidateBodyTrigger
{
    [ValidateBody(typeof(object), "application/json")] // TODO: Replace object with test validator
    [FunctionName(nameof(ValidateBodyTrigger))]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
    {
        return new OkObjectResult("Validate succeeded");
    }
}
