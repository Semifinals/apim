namespace Semifinals.Apim.Attributes;

public class ExampleAttribute : OpenApiExampleAttribute
{
    public ExampleAttribute(Type type) : base(type) { }
}
