using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XValidateStatusCode : XElement
{
    public XValidateStatusCode(
        EAction unspecifiedAction,
        params IXValidateStatusCodeChild[] nodes)
        : base("validate-status-code")
    {
        Add(
            new XAttribute("unspecified-status-code-action", unspecifiedAction),
            nodes);
    }
    
    public XValidateStatusCode(
        EAction unspecifiedAction,
        string errorsVariableName,
        params IXValidateStatusCodeChild[] nodes)
        : base("validate-status-code")
    {
        Add(
            new XAttribute("unspecified-status-code-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}
