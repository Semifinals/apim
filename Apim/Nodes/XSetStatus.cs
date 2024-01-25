namespace Semifinals.Apim.Nodes;

public class XSetStatus : XElement
{
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
