namespace Semifinals.Apim.Nodes;

public class XXmlToJson : XElement
{
    public XXmlToJson(
        EXXmlToJsonKind kind,
        EXXmlToJsonApply apply,
        bool considerAcceptHeader = true)
        : base("xml-to-json")
    {
        Add(
            new XAttribute("kind", kind),
            new XAttribute("apply", apply),
            new XAttribute("consider-accept-header", considerAcceptHeader));
    }
}

public enum EXXmlToJsonKind
{
    JavascriptFriendly,
    Direct
}

public enum EXXmlToJsonApply
{
    Always,
    ContentTypeXml
}
