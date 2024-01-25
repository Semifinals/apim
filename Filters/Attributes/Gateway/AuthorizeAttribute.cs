using Semifinals.Filters.Policies;

namespace Semifinals.Filters.Gateway;

public sealed class AuthorizeAttribute : PolicyAttribute
{
    public AuthorizeAttribute() : base()
    {
        Policy = new AuthorizePolicy();
    }
}

// TODO: Setup reading attributes to build complete xml for policies
// TODO: Figure out how to deploy policies to APIM
// TODO: Figure out a way to document the policies in conjunction with OpenAPI
// TODO: Setup guardian to handle the requests auth requests
