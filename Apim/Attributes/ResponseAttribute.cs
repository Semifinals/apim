using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public class ResponseAttribute : OpenApiResponseWithoutBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; }

    public ResponseAttribute(HttpStatusCode statusCode) : base(statusCode)
    {
        Policy = new ResponsePolicy(statusCode);
    }
}
