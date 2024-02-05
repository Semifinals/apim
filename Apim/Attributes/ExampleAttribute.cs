namespace Semifinals.Apim.Attributes;

/// <summary>
/// Adds an example response to the OpenAPI spec.
/// </summary>
public class ExampleAttribute : OpenApiExampleAttribute
{
    public ExampleAttribute(Type type) : base(type) { }
}
