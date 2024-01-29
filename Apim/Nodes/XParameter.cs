using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XParameter : XElement, IXHeadersChild, IXPathChild, IXQueryChild
{
    public XParameter(
        string name,
        EAction action)
        : base("parameter")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("action", action));
    }
}
