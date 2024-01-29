using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

public sealed class AuthorizeAttribute : PolicyAttribute
{
    public AuthorizeAttribute() : base()
    {
        Policy = new AuthorizePolicy(Priority);
    }
}
