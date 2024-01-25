namespace Semifinals.Filters.Policies.Nodes;

public class XContent : XElement
{
    public XContent(
        string type,
        XContentValidationType validateAs,
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

public enum XContentValidationType
{
    Json,
    Xml,
    Soap
}
