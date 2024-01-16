using Semifinals.Filters.Exceptions;
using Semifinals.Filters.Extensions;

namespace Semifinals.Filters;

#pragma warning disable 0618
/// <summary>
/// Require the request to come from an authorized user.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute
    : Attribute, IFunctionInvocationFilter, IFunctionExceptionFilter
{
    public readonly int[] Roles;

    public AuthorizeAttribute(params int[] roles) : base()
    {
        Roles = roles;
    }

    async Task IFunctionInvocationFilter.OnExecutingAsync(
        FunctionExecutingContext executingContext,
        CancellationToken cancellationToken)
    {
        Console.WriteLine("OnExecutingAsync");

        var req = executingContext.GetRequest();

        // TODO: Handle auth here
        bool authenticated = true;
        bool authorized = false;

        if (!authenticated)
            throw await req.HttpContext.Response.UnauthorizedResult();

        if (!authorized)
            throw await req.HttpContext.Response.ForbiddenResult();
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
        catch (AuthorizeFailureException)
        {
            // Accept failures resulted by bad authorization
        }
        catch (Exception ex)
        {
            // TODO: Appropriately handle unexpected exceptions
            Console.WriteLine($"Unexpected error occurred: {ex.GetType().Name}");
        }

        return Task.CompletedTask;
    }
}
#pragma warning restore 0618
