namespace Semifinals.Apim.Nodes;

public class XSetStatus : XElement, IXReturnResponseChild
{
    public XSetStatus(HttpStatusCode code, string reason) : base("set-status")
    {
        Add(
            new XAttribute("code", (int)code),
            new XAttribute("reason", reason));
    }
    
    public XSetStatus(int code, string reason) : base("set-status")
    {
        Add(
            new XAttribute("code", code),
            new XAttribute("reason", reason));
    }

    public XSetStatus(string code, string reason) : base("set-status")
    {
        Add(
            new XAttribute("code", code),
            new XAttribute("reason", reason));
    }
}
