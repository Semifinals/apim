using Semifinals.Apim.Enums;
using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Templates;

public class ValidateStatusCodeTemplate : Template
{
    public ValidateStatusCodeTemplate(HttpStatusCode statusCode) : base()
    {
        Add(
            new XValidateStatusCode(
                unspecifiedAction: EAction.Prevent,
                new XStatusCode(statusCode, EAction.Ignore)));
    }
}
