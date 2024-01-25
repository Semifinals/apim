using Semifinals.Apim.Policies.Fragments;
using Semifinals.Apim.Policies.Nodes;

namespace Semifinals.Apim.Policies;

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
