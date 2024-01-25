namespace Semifinals.Apim.Nodes;

public class XReturnResponse : XElement
{
    public XReturnResponse(params XNode[] nodes) : base("return-response")
    {
        Add(nodes);
    }
}
