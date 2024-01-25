namespace Semifinals.Apim.Nodes;

public class XSendRequest : XElement
{
    public XSendRequest(
        string responseVariableName,
        params IXSendRequestChild[] nodes)
        : base("send-request")
    {
        Add(
            new XAttribute("response-variable-name", responseVariableName),
            nodes);
    }
    
    public XSendRequest(
        string responseVariableName,
        EXSendRequestMode mode = EXSendRequestMode.New,
        int timeout = 60,
        bool ignoreError = false,
        params IXSendRequestChild[] nodes)
        : base("send-request")
    {
        Add(
            new XAttribute("mode", mode.ToString().ToLower()),
            new XAttribute("response-variable-name", responseVariableName),
            new XAttribute("timeout", timeout),
            new XAttribute("ignoreError", ignoreError),
            nodes);
    }
}

public enum EXSendRequestMode
{
    New,
    Copy
}

public interface IXSendRequestChild { }
