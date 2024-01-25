namespace Semifinals.Apim.Nodes;

public class XSetBody : XElement
{
    public XSetBody(string template, string value) : base("set-body")
    {
        Add(
            value,
            new XAttribute("template", template));
    }
}
