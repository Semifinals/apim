namespace Semifinals.Apim.Nodes;

public class XValidateStatusCode : XElement
{
    public XValidateStatusCode(
        EXValidateStatusCodeUnspecifiedAction unspecifiedAction,
        params IXValidateStatusCodeChild[] nodes)
        : base("validate-status-code")
    {
        Add(
            new XAttribute("unspecified-status-code-action", unspecifiedAction),
            nodes);
    }
    
    public XValidateStatusCode(
        EXValidateStatusCodeUnspecifiedAction unspecifiedAction,
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

public enum EXValidateStatusCodeUnspecifiedAction
{
    Ignore,
    Prevent,
    Detect
}

public interface IXValidateStatusCodeChild { }
