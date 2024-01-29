using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XChoose : XElement
{
    public XChoose(params IXChooseChild[] nodes) : base("choose")
    {
        Add(nodes);
    }
}
