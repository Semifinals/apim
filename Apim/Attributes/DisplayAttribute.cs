using OpenApiDisplayAttribute = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.DisplayAttribute;

namespace Semifinals.Apim.Attributes;

/// <summary>
/// Changes the display name of the endpoint in the OpenAPI spec.
/// </summary>
public class DisplayAttribute : OpenApiDisplayAttribute
{
    public DisplayAttribute(string name) : base(name) { }
}
