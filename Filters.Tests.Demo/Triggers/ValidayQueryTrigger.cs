using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Semifinals.Filters;

public class ValidateQueryTrigger
{
    [ValidateQuery(typeof(object))] // TODO: Replace object with test validator
    [FunctionName(nameof(ValidateQueryTrigger))]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
    {
        return new OkObjectResult("Validate succeeded");
    }
}
