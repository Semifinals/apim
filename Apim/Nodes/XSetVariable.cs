namespace Semifinals.Apim.Nodes;

public class XSetVariable : XElement
{
    public XSetVariable(string name, string value) : base("set-variable")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("value", value));
    }
}
