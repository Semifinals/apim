using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XSetHeader : XElement, IXReturnResponseChild, IXSendOneWayRequestChild, IXSendRequestChild
{
    public XSetHeader(
        string name,
        params IXSetHeaderChild[] nodes)
        : base("set-header")
    {
        Add(
            new XAttribute("name", name),
            nodes);
    }
    
    public XSetHeader(
        string name,
        EExistsAction existsAction = EExistsAction.Override,
        params IXSetHeaderChild[] nodes)
        : base("set-header")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("exists-action", existsAction),
            nodes);
    }
}
