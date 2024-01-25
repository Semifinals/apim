namespace Semifinals.Filters.Policies.Nodes;

public class XChoose : XElement
{
    public XChoose(params XNode[] nodes) : base("choose")
    {
        Add(nodes);
    }
}
