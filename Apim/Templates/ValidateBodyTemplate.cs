using Semifinals.Apim.Enums;
using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Templates;

public class ValidateBodyTemplate : Template
{
    public ValidateBodyTemplate(string contentType)
        : base()
    {
        var type = contentType switch
        {
            "application/json" => EXContentValidationType.Json,
            "application/xml" => EXContentValidationType.Xml,
            _ => throw new ArgumentException("Unsupported content type")
        };
        
        Add(
            new XValidateContent(
                unspecifiedContentTypeAction: EAction.Prevent,
                maxSize: 1024 * 1024 * 2,
                sizeExceededAction: EAction.Prevent,
                new XContent(
                    type: contentType,
                    validateAs: type)));
    }
}
