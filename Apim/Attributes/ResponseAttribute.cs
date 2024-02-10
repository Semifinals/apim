using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

/// <summary>
/// Adds a valid response status code to an endpoint without a body in the response.
/// </summary>
[AttributeUsage(validOn: AttributeTargets.Method, AllowMultiple = true)]
public class ResponseAttribute : OpenApiResponseWithoutBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; }

    public ResponseAttribute(HttpStatusCode statusCode) : base(statusCode)
    {
        Policy = new ResponsePolicy(statusCode);
    }
}
