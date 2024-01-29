using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XSetMethod : XElement, IXSendOneWayRequestChild, IXSendRequestChild
{
    public XSetMethod(HttpMethod method) : base("set-method")
    {
        Add(method.Method);
    }
}
