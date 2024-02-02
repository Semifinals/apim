using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XContent : XElement, IXValidateContentChild
{
    public XContent(
        string type,
        EXContentValidationType validateAs,
        string? schemaId = null,
        string? schemaRef = null,
        bool? allowAdditionalProperties = null)
        : base("content")
    {
        Add(
            new XAttribute("type",
                type),
            new XAttribute("validate-as",
                validateAs.ToString().ToLower()));

        if (allowAdditionalProperties is not null)
            Add(new XAttribute("allow-additional-properties",
                allowAdditionalProperties));

        if (schemaId is not null)
            Add(new XAttribute("schema-id",
                schemaId));

        if (schemaRef is not null)
            Add(new XAttribute("schema-ref",
                schemaRef));
    }
}
