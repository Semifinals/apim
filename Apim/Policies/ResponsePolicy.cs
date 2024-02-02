using Semifinals.Apim.Nodes;
using Semifinals.Apim.Templates;

namespace Semifinals.Apim.Policies;

public sealed class ResponsePolicy : Policy
{
    public ResponsePolicy(HttpStatusCode statusCode) : base()
    {
        Inbound.Add(new XBase());
        Backend.Add(new XBase());
        Outbound.Add(new ResponseTemplate(statusCode), new XBase());
        OnError.Add(new XBase());
    }
}
