using Semifinals.Filters.Exceptions;
using Semifinals.Filters.Extensions;

namespace Semifinals.Filters;

#pragma warning disable 0618
/// <summary>
/// Validate the request body or query params.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public abstract class AValidateAttribute
    : Attribute, IFunctionInvocationFilter, IFunctionExceptionFilter
{
    async Task IFunctionInvocationFilter.OnExecutingAsync(
        FunctionExecutingContext executingContext,
        CancellationToken cancellationToken)
    {
        var req = executingContext.GetRequest();
        var errors = await ValidateAsync(req);

        if (errors.Length > 0)
            throw await req.HttpContext.Response.BadRequestObjectResult(errors);
    }

    Task IFunctionInvocationFilter.OnExecutedAsync(
        FunctionExecutedContext executedContext,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    Task IFunctionExceptionFilter.OnExceptionAsync(
        FunctionExceptionContext exceptionContext,
        CancellationToken cancellationToken)
    {
        try
        {
            throw exceptionContext.Exception.InnerException!;
        }
        catch (ValidationFailureException)
        {
            // Accept failures resulted by bad validation
        }
        catch (Exception ex)
        {
            // TODO: Appropriately handle unexpected exceptions
            Console.WriteLine($"Unexpected error occurred: {ex.GetType().Name}");
        }

        return Task.CompletedTask;
    }

    public abstract Task<string[]> ValidateAsync(HttpRequest req);
    // TODO: Replace string with more appropriate validation failure type
}
#pragma warning restore 0618
