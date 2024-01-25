using Semifinals.Apim.Policies.Nodes;

namespace Semifinals.Apim.Policies;

public sealed class DefaultPolicy : Policy
{
    public DefaultPolicy() : base()
    {
        Inbound.Add(new XBase());
        Backend.Add(new XBase());
        Outbound.Add(new XBase());
        OnError.Add(new XBase());
    }
}
