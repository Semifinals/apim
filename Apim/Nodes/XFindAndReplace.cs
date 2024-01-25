namespace Semifinals.Apim.Nodes;

public class XFindAndReplace : XElement
{
    public XFindAndReplace(string from, string to) : base("find-and-replace")
    {
        Add(
            new XAttribute("from", from),
            new XAttribute("to", to));
    }
}
