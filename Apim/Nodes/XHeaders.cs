namespace Semifinals.Apim.Nodes;

public class XHeaders : XElement, XValidateParametersChild
{
    public XHeaders(
        string name,
        XHeadersSpecifiedParameterAction specifiedAction,
        XHeadersUnspecifiedParameterAction unspecifiedAction)
        : base("headers")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction));
    }
}

public enum XHeadersSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum XHeadersUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface XHeadersChild { }
