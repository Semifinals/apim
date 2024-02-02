using OpenApiDisplayAttribute = Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes.DisplayAttribute;

namespace Semifinals.Apim.Attributes;

public class DisplayAttribute : OpenApiDisplayAttribute
{
    public DisplayAttribute(string name) : base(name) { }
}
