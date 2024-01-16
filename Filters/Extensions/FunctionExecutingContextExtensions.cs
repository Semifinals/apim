namespace Semifinals.Filters.Extensions;

#pragma warning disable 0618
public static class FunctionExecutingContextExtensions
{
    /// <summary>
    /// Get the HttpRequest from a function's executing context.
    /// </summary>
    public static HttpRequest GetRequest(this FunctionExecutingContext context)
    {
        return (HttpRequest)context.Arguments["req"];
    }
}
#pragma warning restore 0618
