namespace Semifinals.Apim.Nodes;

public class XSendRequest : XElement
{
    public XSendRequest(
        string mode,
        string responseVariableName,
        int timeout,
        bool ignoreError,
        params XNode[] nodes)
        : base("send-request")
    {
        Add(
            new XAttribute("mode", mode),
            new XAttribute("response-variable-name", responseVariableName),
            new XAttribute("timeout", timeout),
            new XAttribute("ignoreError", ignoreError),
            nodes);
    }
}
