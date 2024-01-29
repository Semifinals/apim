using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XSetQueryParameter : XElement, IXSendOneWayRequestChild, IXSendRequestChild
{
    public XSetQueryParameter(
        string name,
        params IXSetQueryParameterChild[] nodes) : base("set-query-parameter")
    {
        Add(
            new XAttribute("name", name),
            nodes);
    }    
    
    public XSetQueryParameter(
        string name,
        EExistsAction existsAction = EExistsAction.Override,
        params IXSetQueryParameterChild[] nodes) : base("set-query-parameter")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("existsAction", existsAction),
            nodes);
    }
}

