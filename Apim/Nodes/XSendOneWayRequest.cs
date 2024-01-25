namespace Semifinals.Apim.Nodes;

public class XSendOneWayRequest : XElement
{
    public XSendOneWayRequest(
        string mode,
        int timeout,
        params XNode[] nodes)
        : base("send-one-way-request")
    {
        Add(
            new XAttribute("mode", mode),
            new XAttribute("timeout", timeout),
            nodes);
    }
}
