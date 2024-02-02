using Semifinals.Apim.Nodes;
using Semifinals.Apim.Templates;

namespace Semifinals.Apim.Policies;

public sealed class ResponseBodyPolicy : Policy
{
    public ResponseBodyPolicy(
        HttpStatusCode statusCode,
        string contentType)
        : base()
    {
        Inbound.Add(new XBase());
        Backend.Add(new XBase());
        Outbound.Add(
            new ValidateStatusCodeTemplate(statusCode),
            new ValidateBodyTemplate(contentType),
            new XBase());
        OnError.Add(new XBase());
    }
}
