namespace Semifinals.Apim.Nodes;

public class XStatusCode : XElement, XValidateStatusCodeChild
{
    public XStatusCode(
        HttpStatusCode code,
        XStatusCodeAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }

    public XStatusCode(
        int code,
        XStatusCodeAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }
    
    public XStatusCode(
        string code,
        XStatusCodeAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }
}

public enum XStatusCodeAction
{
    Ignore,
    Prevent,
    Detect
}
