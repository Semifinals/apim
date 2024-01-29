using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XValue : XElement, IXSetHeaderChild, IXSetQueryParameterChild
{
    public XValue(string value) : base("value")
    {
        Add(value);
    }
}
