namespace Semifinals.Apim.Nodes;

public class XStatusCode : XElement, IXValidateStatusCodeChild
{
    public XStatusCode(
        HttpStatusCode code,
        EXStatusCodeAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }

    public XStatusCode(
        int code,
        EXStatusCodeAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }
    
    public XStatusCode(
        string code,
        EXStatusCodeAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }
}

public enum EXStatusCodeAction
{
    Ignore,
    Prevent,
    Detect
}
