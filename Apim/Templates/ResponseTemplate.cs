using Semifinals.Apim.Enums;
using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Templates;

public class ResponseTemplate : Template
{
    public ResponseTemplate(HttpStatusCode statusCode) : base()
    {
        Add(
            new XValidateStatusCode(
                EAction.Prevent,
                new XStatusCode(statusCode, EAction.Ignore)));
    }
}
