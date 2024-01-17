using Semifinals.Filters.Exceptions;
using Semifinals.Filters.Strategies.ContentSerializer;

namespace Semifinals.Filters.Extensions;

public static class HttpResponseExtensions
{
    /// <summary>
    /// Sets the response to a bad request result including the reason for 
    /// failure and returns the exception to throw to trigger it.
    /// </summary>
    public static async Task<ValidationFailureException> BadRequestObjectResult(
        this HttpResponse res,
        object body)
    {
        res.StatusCode = 400;

        var serializer = ContentSerializerProvider.GetSerializer("application/json");
        res.Headers.Set("Content-Type", "application/json");

        res.Body.Position = 0;
        await serializer.SerializeAsync(res.Body, body);
        await res.Body.FlushAsync();
        res.Body.Close();

        return new ValidationFailureException(HttpStatusCode.BadRequest);
    }

    /// <summary>
    /// Sets the response to an unauthorized result and returns the exception
    /// to throw to trigger it.
    /// </summary>
    public static Task<AuthorizeFailureException> UnauthorizedResult(
        this HttpResponse res)
    {
        res.StatusCode = 401;

        //await res.Body.FlushAsync();
        //res.Body.Close();

        return Task.FromResult(
            new AuthorizeFailureException(HttpStatusCode.Unauthorized));
    }

    /// <summary>
    /// Sets the response to a forbidden result and returns the exception to
    /// throw to trigger it.
    /// </summary>
    public static Task<AuthorizeFailureException> ForbiddenResult(
        this HttpResponse res)
    {
        res.StatusCode = 403;

        //await res.Body.FlushAsync();
        //res.Body.Close();

        return Task.FromResult(
            new AuthorizeFailureException(HttpStatusCode.Forbidden));
    }
}
