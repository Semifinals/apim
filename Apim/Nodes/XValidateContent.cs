namespace Semifinals.Apim.Nodes;

public class XValidateContent : XElement
{
    public XValidateContent(
        XValidateContentAction unspecifiedContentTypeAction,
        int maxSize,
        XValidateContentAction sizeExceededAction,
        string errorsVariableName) : base("validate-content")
    {
        Add(
            new XAttribute("unspecified-content-type-action",
                unspecifiedContentTypeAction.ToString().ToLower()),
            new XAttribute("max-size",
                maxSize),
            new XAttribute("size-exceeded-action",
                sizeExceededAction.ToString().ToLower()),
            new XAttribute("errors-variable-name",
                errorsVariableName));
    }
}

public enum XValidateContentAction
{
    Ignore,
    Prevent,
    Detect
}
