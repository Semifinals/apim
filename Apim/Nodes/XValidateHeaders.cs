using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XValidateHeaders : XElement
{
    public XValidateHeaders(
        EAction specifiedAction,
        EAction unspecifiedAction,
        params IXValidateHeadersChild[] nodes)
        : base("validate-headers")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }

    public XValidateHeaders(
        EAction specifiedAction,
        EAction unspecifiedAction,
        string errorsVariableName,
        params IXValidateHeadersChild[] nodes)
        : base("validate-headers")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}
