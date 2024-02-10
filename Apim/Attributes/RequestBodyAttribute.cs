using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

/// <summary>
/// Adds a valid request body and content type for an endpoint.
/// </summary>
[AttributeUsage(validOn: AttributeTargets.Method, AllowMultiple = true)]
public class RequestBodyAttribute : OpenApiRequestBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; }

    public RequestBodyAttribute(
        string contentType,
        Type bodyType)
        : base(contentType, bodyType)
    {
        Policy = new RequestBodyPolicy(contentType);
    }
}
