namespace Semifinals.Apim.Nodes;

public class XChoose : XElement
{
    public XChoose(params XNode[] nodes) : base("choose")
    {
        Add(nodes);
    }
}
