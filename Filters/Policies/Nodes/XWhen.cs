namespace Semifinals.Filters.Policies.Nodes;

public class XWhen : XElement
{
    public XWhen(string condition, params XNode[] nodes) : base("when")
    {
        Add(
            nodes,
            new XAttribute("condition", condition));
    }
}
