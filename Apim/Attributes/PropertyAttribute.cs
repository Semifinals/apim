namespace Semifinals.Apim.Attributes;

/// <summary>
/// Outlines the usage of a property in the OpenAPI spec.
/// </summary>
[AttributeUsage(validOn: AttributeTargets.Method, AllowMultiple = true)]
public class PropertyAttribute : OpenApiPropertyAttribute
{
}
