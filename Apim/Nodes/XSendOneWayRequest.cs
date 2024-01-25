namespace Semifinals.Apim.Nodes;

public class XSendOneWayRequest : XElement
{
    public XSendOneWayRequest(params IXSendOneWayRequestChild[] nodes)
        : base("send-one-way-request")
    {
        Add(nodes);
    }
    
    public XSendOneWayRequest(
        EXSendOneWayRequestMode mode = EXSendOneWayRequestMode.New,
        int timeout = 60,
        params IXSendOneWayRequestChild[] nodes)
        : base("send-one-way-request")
    {
        Add(
            new XAttribute("mode", mode.ToString().ToLower()),
            new XAttribute("timeout", timeout),
            nodes);
    }
}

public enum EXSendOneWayRequestMode
{
    New,
    Copy
}

public interface IXSendOneWayRequestChild { }
