using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XHeader : XElement, IXValidateHeadersChild
{
    public XHeader(
        string name,
        EAction action)
        : base("header")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("action", action));
    }
}
