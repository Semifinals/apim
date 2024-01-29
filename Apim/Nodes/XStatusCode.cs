using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XStatusCode : XElement, IXValidateStatusCodeChild
{
    public XStatusCode(
        HttpStatusCode code,
        EAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }

    public XStatusCode(
        int code,
        EAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }
    
    public XStatusCode(
        string code,
        EAction action)
        : base("status-code")
    {
        Add(
            new XAttribute("status-code", code),
            new XAttribute("action", action));
    }
}
