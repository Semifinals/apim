using System.Net;

namespace Semifinals.Filters.Exceptions;

public class AuthorizeFailureException : Exception
{
    public readonly HttpStatusCode StatusCode;

    public AuthorizeFailureException(HttpStatusCode statusCode) : base()
    {
        StatusCode = statusCode;
    }
}
