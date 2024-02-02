using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public class RequestBodyAttribute : OpenApiRequestBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; } = new DefaultPolicy(); // TODO: Make request validation policy

    public RequestBodyAttribute(string contentType, Type bodyType)
        : base(contentType, bodyType) { }
}
