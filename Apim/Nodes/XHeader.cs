namespace Semifinals.Apim.Nodes;

public class XHeader : XElement, XValidateHeadersChild
{
    public XHeader(
        string name,
        XParameterAction action)
        : base("header")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("action", action));
    }
}

public enum XHeaderAction
{
    Ignore,
    Prevent,
    Detect
}
