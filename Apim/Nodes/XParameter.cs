namespace Semifinals.Apim.Nodes;

public class XParameter : XElement, XHeadersChild, XPathChild, XQueryChild
{
    public XParameter(
        string name,
        XParameterAction action)
        : base("parameter")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("action", action));
    }
}

public enum XParameterAction
{
    Ignore,
    Prevent,
    Detect
}
