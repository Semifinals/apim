using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public interface IPolicyAttribute
{
    public int Priority { get; init; }

    public Policy Policy { get; }
}
