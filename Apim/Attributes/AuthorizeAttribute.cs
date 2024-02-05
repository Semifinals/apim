using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

/// <summary>
/// Requires the request be authorized to reach the endpoint.
/// </summary>
public sealed class AuthorizeAttribute : IPolicyAttribute // TODO: Extend OpenApiSecurityAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; } = new AuthorizePolicy();
}
