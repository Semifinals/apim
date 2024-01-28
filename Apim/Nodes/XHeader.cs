namespace Semifinals.Apim.Nodes;

public class XHeader : XElement, IXValidateHeadersChild
{
    public XHeader(
        string name,
        EXHeaderAction action)
        : base("header")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("action", action));
    }
}

public enum EXHeaderAction
{
    Ignore,
    Prevent,
    Detect
}
