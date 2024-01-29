using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XQuery : XElement, IXValidateParametersChild
{
    public XQuery(
        string name,
        EAction specifiedAction,
        EAction unspecifiedAction)
        : base("query")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction));
    }
}
