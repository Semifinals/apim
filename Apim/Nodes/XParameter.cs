namespace Semifinals.Apim.Nodes;

public class XParameter : XElement, IXHeadersChild, IXPathChild, IXQueryChild
{
    public XParameter(
        string name,
        EXParameterAction action)
        : base("parameter")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("action", action));
    }
}

public enum EXParameterAction
{
    Ignore,
    Prevent,
    Detect
}
