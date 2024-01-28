namespace Semifinals.Apim.Nodes;

public class XMockResponse : XElement
{
    public XMockResponse(
        HttpStatusCode code,
        string contentType)
        : base("mock-response")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("content-type", contentType));
    }

    public XMockResponse(
        int code,
        string contentType)
        : base("mock-response")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("content-type", contentType));
    }
    
    public XMockResponse(
        string code,
        string contentType)
        : base("mock-response")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("content-type", contentType));
    }
}
