using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public class ResponseAttribute : OpenApiResponseWithoutBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; } = new DefaultPolicy(); // TODO: Make response validation policy

    public ResponseAttribute(HttpStatusCode statusCode) : base(statusCode) { }
}
