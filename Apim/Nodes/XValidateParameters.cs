using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XValidateParameters : XElement
{
    public XValidateParameters(
        EAction specifiedAction,
        EAction unspecifiedAction,
        params IXValidateParametersChild[] nodes)
        : base("validate-parameters")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }
    
    public XValidateParameters(
        EAction specifiedAction,
        EAction unspecifiedAction,
        string errorsVariableName,
        params IXValidateParametersChild[] nodes)
        : base("validate-parameters")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}
