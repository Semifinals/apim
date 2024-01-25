namespace Semifinals.Apim.Nodes;

public class XReturnResponse : XElement
{
    public XReturnResponse(params IXReturnResponseChild[] nodes)
        : base("return-response")
    {
        Add(nodes);
    }
    
    public XReturnResponse(
        string responseVariableName,
        params IXReturnResponseChild[] nodes)
        : base("return-response")
    {
        Add(
            new XAttribute("response-variable-name", responseVariableName),
            nodes);
    }
}

public interface IXReturnResponseChild { }
