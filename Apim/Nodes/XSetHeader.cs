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
        EXSetHeaderExistsAction existsAction = EXSetHeaderExistsAction.Override,
        params IXSetHeaderChild[] nodes)
        : base("set-header")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("exists-action", existsAction),
            nodes);
    }
}

public enum EXSetHeaderExistsAction
{
    Override,
    Skip,
    Append,
    Delete
}

public interface IXSetHeaderChild { }
