namespace Semifinals.Apim.Nodes;

public class XPath : XElement, XValidateParametersChild
{
    public XPath(
        string name,
        XPathSpecifiedParameterAction specifiedAction)
        : base("path")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction));
    }
}

public enum XPathSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface XPathChild { }
