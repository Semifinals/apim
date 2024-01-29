using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XSetUrl : XElement, IXSendOneWayRequestChild, IXSendRequestChild
{
    public XSetUrl(string url) : base("set-url")
    {
        Add(url);
    }
}
