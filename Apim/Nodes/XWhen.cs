using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XWhen : XElement, IXChooseChild
{
    public XWhen(string condition, params XNode[] nodes) : base("when")
    {
        Add(
            new XAttribute("condition", condition),
            nodes);
    }
}
