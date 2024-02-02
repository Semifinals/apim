using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public class ResponseBodyAttribute : OpenApiResponseWithBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; } = new DefaultPolicy(); // TODO: Make response validation policy

    public ResponseBodyAttribute(
        HttpStatusCode statusCode,
        string contentType,
        Type bodyType)
        : base(statusCode, contentType, bodyType) { }
}
