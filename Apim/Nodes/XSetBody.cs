namespace Semifinals.Apim.Nodes;

public class XSetBody : XElement, IXReturnResponseChild, IXSendOneWayRequestChild, IXSendRequestChild
{
    public XSetBody(string value) : base("set-body")
    {
        Add(value);
    }
    
    public XSetBody(EXSetBodyTemplate template, string value) : base("set-body")
    {
        Add(
            new XAttribute("template", template),
            value);
    }
}

public enum EXSetBodyTemplate
{
    Liquid
}
