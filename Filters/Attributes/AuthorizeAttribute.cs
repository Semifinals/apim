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
    public AuthorizeAttribute(params int[] roles) : base()
    {
    }

    async Task IFunctionInvocationFilter.OnExecutingAsync(
        FunctionExecutingContext executingContext,
        CancellationToken cancellationToken)
    {
        Console.WriteLine("OnExecutingAsync");
        bool authorized = true;
        bool authenticated = true;

        var req = executingContext.GetRequest();

        if (!authenticated)
            throw await req.HttpContext.Response.UnauthorizedResult();

        if (!authorized)
            throw await req.HttpContext.Response.ForbiddenResult();
    }

    Task IFunctionInvocationFilter.OnExecutedAsync(
        FunctionExecutedContext executedContext,
        CancellationToken cancellationToken)
    {
        Console.WriteLine("OnExecutedAsync");
        return Task.CompletedTask;
    }

    Task IFunctionExceptionFilter.OnExceptionAsync(
        FunctionExceptionContext exceptionContext,
        CancellationToken cancellationToken)
    {
        try
        {
            throw exceptionContext.Exception;
        }
        catch (AuthorizeFailureException)
        {
            Console.WriteLine("OnExceptionAsync: Known error");
        }
        catch (Exception)
        {
            Console.WriteLine("OnExceptionAsync: Unknown error");
        }

        return Task.CompletedTask;
    }
}
#pragma warning restore 0618
