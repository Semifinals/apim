namespace Semifinals.Apim.Attributes;

/// <summary>
/// Outlines the usage of a parameter in the OpenAPI spec.
/// </summary>
public class ParameterAttribute : OpenApiParameterAttribute
{
    public ParameterAttribute(string name) : base(name) { }
}
