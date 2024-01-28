namespace Semifinals.Apim.Nodes;

public class XValidateStatusCode : XElement
{
    public XValidateStatusCode(
        XValidateStatusCodeUnspecifiedAction unspecifiedAction,
        params XValidateStatusCodeChild[] nodes)
        : base("validate-status-code")
    {
        Add(
            new XAttribute("unspecified-status-code-action", unspecifiedAction),
            nodes);
    }
    
    public XValidateStatusCode(
        XValidateStatusCodeUnspecifiedAction unspecifiedAction,
        string errorsVariableName,
        params XValidateStatusCodeChild[] nodes)
        : base("validate-status-code")
    {
        Add(
            new XAttribute("unspecified-status-code-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}

public enum XValidateStatusCodeUnspecifiedAction
{
    Ignore,
    Prevent,
    Detect
}

public interface XValidateStatusCodeChild { }
