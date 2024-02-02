using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XType : XElement, IXContentTypeMapChild
{
    public XType(
        string to,
        string? from = null,
        string? when = null)
        : base("type")
    {
        if (from is null && when is null)
            throw new ArgumentException("'from' and 'when' cannot both be null");

        if (from is not null && when is not null)
            throw new ArgumentException("'from' and 'when' cannot both be defined");

        if (from is not null)
            Add(new XAttribute("from", from));

        if (when is not null)
            Add(new XAttribute("when", when));

        Add(new XAttribute("to", to));
    }
}
