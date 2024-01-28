namespace Semifinals.Apim.Nodes;

public class XXmlToJson : XElement
{
    public XXmlToJson(
        XXmlToJsonKind kind,
        XXmlToJsonApply apply,
        bool considerAcceptHeader = true)
        : base("xml-to-json")
    {
        Add(
            new XAttribute("kind", kind),
            new XAttribute("apply", apply),
            new XAttribute("consider-accept-header", considerAcceptHeader));
    }
}

public enum XXmlToJsonKind
{
    JavascriptFriendly,
    Direct
}

public enum XXmlToJsonApply
{
    Always,
    ContentTypeXml
}
