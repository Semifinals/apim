namespace Semifinals.Apim.Nodes;

public class XValidateHeaders : XElement
{
    public XValidateHeaders(
        XValidateHeadersSpecifiedParameterAction specifiedAction,
        XValidateHeadersUnspecifiedParameterAction unspecifiedAction,
        params XValidateHeadersChild[] nodes)
        : base("validate-headers")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }

    public XValidateHeaders(
        XValidateHeadersSpecifiedParameterAction specifiedAction,
        XValidateHeadersUnspecifiedParameterAction unspecifiedAction,
        string errorsVariableName,
        params XValidateHeadersChild[] nodes)
        : base("validate-headers")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}

public enum XValidateHeadersSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum XValidateHeadersUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface XValidateHeadersChild { }
