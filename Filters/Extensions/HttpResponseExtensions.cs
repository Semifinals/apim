using Semifinals.Filters.Exceptions;

namespace Semifinals.Filters.Extensions;

public static class HttpResponseExtensions
{
    /// <summary>
    /// Sets the response to an unauthorized result and returns the exception
    /// to throw to trigger it.
    /// </summary>
    public static async Task<AuthorizeFailureException> UnauthorizedResult(
        this HttpResponse res)
    {
        res.StatusCode = 401;
        await res.Body.FlushAsync();
        res.Body.Close();

        return new AuthorizeFailureException(HttpStatusCode.Unauthorized);
    }

    /// <summary>
    /// Sets the response to a forbidden result and returns the exception to
    /// throw to trigger it.
    /// </summary>
    public static async Task<AuthorizeFailureException> ForbiddenResult(
        this HttpResponse res)
    {
        res.StatusCode = 403;
        await res.Body.FlushAsync();
        res.Body.Close();

        return new AuthorizeFailureException(HttpStatusCode.Forbidden);
    }
}
