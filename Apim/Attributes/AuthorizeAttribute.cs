using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

/// <summary>
/// Requires the request be authorized to reach the endpoint.
/// </summary>
[AttributeUsage(validOn: AttributeTargets.Method, AllowMultiple = true)]
public sealed class AuthorizeAttribute : OpenApiSecurityAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; }

    public AuthorizeAttribute(params int[] permissionsRequired)
        : base("SFT", SecuritySchemeType.Http)
    {
        Policy = new AuthorizePolicy(permissionsRequired);
        BearerFormat = "SFT";
        Description = "Authenticate using a Semifinals bearer token";
        In = OpenApiSecurityLocationType.Header;
        Scheme = OpenApiSecuritySchemeType.Bearer;
    }
}
