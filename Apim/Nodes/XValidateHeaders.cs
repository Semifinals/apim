namespace Semifinals.Apim.Nodes;

public class XValidateHeaders : XElement
{
    public XValidateHeaders(
        EXValidateHeadersSpecifiedParameterAction specifiedAction,
        EXValidateHeadersUnspecifiedParameterAction unspecifiedAction,
        params IXValidateHeadersChild[] nodes)
        : base("validate-headers")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }

    public XValidateHeaders(
        EXValidateHeadersSpecifiedParameterAction specifiedAction,
        EXValidateHeadersUnspecifiedParameterAction unspecifiedAction,
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

public enum EXValidateHeadersSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum EXValidateHeadersUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface IXValidateHeadersChild { }
