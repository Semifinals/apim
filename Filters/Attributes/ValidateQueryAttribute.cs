using Semifinals.Filters.Strategies.ContentSerializer;

namespace Semifinals.Filters;

public class ValidateQueryAttribute : AValidateAttribute
{
    private readonly AbstractValidator<dynamic> QueryValidator;

    public ValidateQueryAttribute(Type queryValidatorType) : base()
    {
        QueryValidator = (AbstractValidator<dynamic>)
            Activator.CreateInstance(queryValidatorType)!;
    }

    public override async Task<string[]> ValidateAsync(HttpRequest req)
    {
        var query = req.Query;

        // TODO: Properly handle validation and errors
        await Task.Delay(1);

        return Array.Empty<string>();
    }
}
