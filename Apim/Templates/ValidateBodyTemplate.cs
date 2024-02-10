using Semifinals.Apim.Enums;
using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Templates;

public class ValidateBodyTemplate : Template
{
    public ValidateBodyTemplate(string contentType)
        : base()
    {
        static XValidateContent Validator(
            EXContentValidationType type,
            string contentType) => new(
                unspecifiedContentTypeAction: EAction.Prevent,
                maxSize: 1024 * 1024 * 2,
                sizeExceededAction: EAction.Prevent,
                new XContent(
                    type: contentType,
                    validateAs: type));

        switch (contentType)
        {
            case "application/json":
                Add(Validator(EXContentValidationType.Json, contentType));
                break;
            case "application/xml":
                Add(Validator(EXContentValidationType.Xml, contentType));
                break;
        }
    }
}
