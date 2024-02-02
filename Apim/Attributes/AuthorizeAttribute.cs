using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public sealed class AuthorizeAttribute : IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; } = new AuthorizePolicy();
}
