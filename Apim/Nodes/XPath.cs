using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XPath : XElement, IXValidateParametersChild
{
    public XPath(string name, EAction specifiedAction) : base("path")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction));
    }
}
