using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Policies;

public sealed class DefaultPolicy : Policy
{
    public DefaultPolicy(int priority) : base(priority)
    {
        Inbound.Add(new XBase());
        Backend.Add(new XBase());
        Outbound.Add(new XBase());
        OnError.Add(new XBase());
    }
}
