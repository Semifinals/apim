using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XContentTypeMap : XElement, IXValidateContentChild
{
    public XContentTypeMap(
        string? anyContentTypeValue = null,
        string? missingContentTypeValue = null,
        params IXContentTypeMapChild[] nodes)
        : base("content-type-map")
    {
        if (anyContentTypeValue is not null)
            Add(new XAttribute("any-content-type-value",
                anyContentTypeValue));

        if (missingContentTypeValue is not null)
            Add(new XAttribute("missing-content-type-value",
                missingContentTypeValue));
        
        Add(nodes);
    }
}
