using Semifinals.Apim.Enums;
using Semifinals.Apim.Interfaces;

namespace Semifinals.Apim.Nodes;

public class XValidateContent : XElement
{
    public XValidateContent(
        EAction unspecifiedContentTypeAction,
        int maxSize,
        EAction sizeExceededAction,
        params IXValidateContentChild[] nodes)
        : base("validate-content")
    {
        Add(
            new XAttribute("unspecified-content-type-action",
                unspecifiedContentTypeAction.ToString().ToLower()),
            new XAttribute("max-size",
                maxSize),
            new XAttribute("size-exceeded-action",
                sizeExceededAction.ToString().ToLower()),
            nodes);
    }
    
    public XValidateContent(
        EAction unspecifiedContentTypeAction,
        int maxSize,
        EAction sizeExceededAction,
        string errorsVariableName,
        params IXValidateContentChild[] nodes)
        : base("validate-content")
    {
        Add(
            new XAttribute("unspecified-content-type-action",
                unspecifiedContentTypeAction.ToString().ToLower()),
            new XAttribute("max-size",
                maxSize),
            new XAttribute("size-exceeded-action",
                sizeExceededAction.ToString().ToLower()),
            new XAttribute("errors-variable-name",
                errorsVariableName),
            nodes);
    }
}
