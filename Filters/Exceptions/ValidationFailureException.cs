namespace Semifinals.Filters.Exceptions;

public class ValidationFailureException : Exception
{
    public readonly HttpStatusCode StatusCode;

    public ValidationFailureException(HttpStatusCode statusCode) : base()
    {
        StatusCode = statusCode;
    }
}
