using Semifinals.Apim.Enums;

namespace Semifinals.Apim.Nodes;

public class XJsonToXml : XElement
{
    public XJsonToXml(
        EXJsonToXmlApply apply,
        char namespaceSeparator,
        string namespacePrefix,
        string attributeBlockName,
        bool contentAcceptHeader = true,
        bool parseDate = true)
        : base("json-to-xml")
    {
        Add(
            new XAttribute("apply", apply),
            new XAttribute("namespace-separator", namespaceSeparator),
            new XAttribute("namespace-prefix", namespacePrefix),
            new XAttribute("attribute-block-name", attributeBlockName),
            new XAttribute("content-accept-header", contentAcceptHeader),
            new XAttribute("parse-date", parseDate));
    }
}
