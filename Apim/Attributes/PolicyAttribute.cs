using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PolicyAttribute : Attribute
{
    public Policy Policy { get; protected set; }

    public PolicyAttribute() : base()
    {
        Policy = new DefaultPolicy();
    }

    public PolicyAttribute(Policy policy) : base()
    {
        Policy = policy;
    }
}
