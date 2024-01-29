using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PolicyAttribute : Attribute
{
    public Policy Policy { get; protected set; }

    public int Priority { get; set; } = -1;

    public PolicyAttribute() : base()
    {
        Policy = new DefaultPolicy(Priority);
    }

    public PolicyAttribute(Policy policy) : base()
    {
        Policy = policy;
    }
}
