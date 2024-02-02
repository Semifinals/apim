using Semifinals.Apim.Nodes;
using Semifinals.Apim.Templates;

namespace Semifinals.Apim.Policies;

public sealed class RequestBodyPolicy : Policy
{
    public RequestBodyPolicy(string contentType) : base()
    {
        Inbound.Add(
            new ValidateBodyTemplate(contentType),
            new XBase());
        Backend.Add(new XBase());
        Outbound.Add(new XBase());
        OnError.Add(new XBase());
    }
}
