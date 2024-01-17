using Semifinals.Filters.Strategies.ContentSerializer;

namespace Semifinals.Filters;

public class ValidateBodyAttribute : AValidateAttribute
{
    private readonly string ContentType;
    private readonly AbstractValidator<dynamic> BodyValidator;

    public ValidateBodyAttribute(
        Type bodyValidatorType,
        string contentType = "application/json")
        : base()
    {
        ContentType = contentType;
        BodyValidator = (AbstractValidator<dynamic>)
            Activator.CreateInstance(bodyValidatorType)!;
    }

    public override async Task<string[]> ValidateAsync(HttpRequest req)
    {
        var serializer = ContentSerializerProvider.GetSerializer(ContentType);
        var body = await serializer.DeserializeAsync<object>(req.Body);

        // TODO: Properly handle validation and errors

        return Array.Empty<string>();
    }
}
