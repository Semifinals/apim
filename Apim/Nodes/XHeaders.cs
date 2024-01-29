using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XHeaders : XElement, IXValidateParametersChild
{
    public XHeaders(
        string name,
        EAction specifiedAction,
        EAction unspecifiedAction,
        params IXHeadersChild[] nodes)
        : base("headers")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }
}
