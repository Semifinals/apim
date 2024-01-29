using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XOtherwise : XElement, IXChooseChild
{
    public XOtherwise(params XNode[] nodes) : base("otherwise")
    {
        Add(nodes);
    }
}
