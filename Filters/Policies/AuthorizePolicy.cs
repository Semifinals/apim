using Semifinals.Filters.Policies.Fragments;
using Semifinals.Filters.Policies.Nodes;

namespace Semifinals.Filters.Policies;

public sealed class AuthorizePolicy : Policy
{
    public AuthorizePolicy() : base()
    {
        Inbound.Add(new XBase(), new AuthorizeFragment());
        Backend.Add(new XBase());
        Outbound.Add(new XBase());
        OnError.Add(new XBase());
    }
}
