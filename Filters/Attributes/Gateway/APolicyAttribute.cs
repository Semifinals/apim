using Semifinals.Filters.Policies;

namespace Semifinals.Filters.Gateway;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public abstract class APolicyAttribute : Attribute
{
    public XElement Inbound { get; protected set; }

    public XElement Backend { get; protected set; }

    public XElement Outbound { get; protected set; }

    public XElement OnError { get; protected set; }

    public APolicyAttribute() : base() { }

    protected void AddPolicy(Policy policy)
    {
        Inbound.Add(policy.Inbound.Elements());
        Backend.Add(policy.Backend.Elements());
        Outbound.Add(policy.Outbound.Elements());
        OnError.Add(policy.OnError.Elements());
    }
}
