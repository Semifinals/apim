using Semifinals.Filters.Policies;

namespace Semifinals.Filters.Gateway;

public class AuthorizeAttribute : APolicyAttribute
{
    public AuthorizeAttribute() : base()
    {
        AddPolicy(new AuthorizePolicy());
    }
}

// TODO: Handle 0, 1, or many <base /> when using many policies
// TODO: Setup reading attributes to build complete xml for policies
// TODO: Figure out how to deploy policies to APIM
// TODO: Figure out a way to document the policies in conjunction with OpenAPI
// TODO: Setup guardian to handle the requests auth requests
