using Semifinals.Apim.Fragments;
using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Policies;

public sealed class AuthorizePolicy : Policy
{
    public AuthorizePolicy(int priority) : base(priority)
    {
        Inbound.Add(new XBase(), new AuthorizeFragment());
        Backend.Add(new XBase());
        Outbound.Add(new XBase());
        OnError.Add(new XBase());
    }
}
