namespace Semifinals.Apim.Nodes;

public class XQuery : XElement, XValidateParametersChild
{
    public XQuery(
        string name,
        XQuerySpecifiedParameterAction specifiedAction,
        XQueryUnspecifiedParameterAction unspecifiedAction)
        : base("query")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction));
    }
}

public enum XQuerySpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum XQueryUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface XQueryChild { }
