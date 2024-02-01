using Semifinals.Apim.CLI.Exceptions;
using Semifinals.Apim.Nodes;
using Semifinals.Apim.Policies;

namespace Semifinals.Apim.CLI.Extensions;

public static class PolicyExtensions
{
    /// <summary>
    /// Nest a policy within another policy by its base.
    /// </summary>
    /// <param name="parent">The outer policy</param>
    /// <param name="child">The inner policy</param>
    /// <returns>A new policy with the child policy replacing the parent's base node</returns>
    /// <exception cref="InvalidPolicyException">Occurs when the parent doesn't have exactly one base node</exception>
    public static Policy Nest(this Policy parent, Policy child)
    {
        static XElement GetBase(XElement element)
        {
            static IEnumerable<XElement> GetNestedElements(XElement element) => element
                .Elements()
                .Concat(element.Elements().SelectMany(e => GetNestedElements(e)));

            var descendents = GetNestedElements(element);
            var baseDelegate = (XElement e) => e.Name == new XBase().Name;

            if (descendents.Count(baseDelegate) != 1)
                throw new InvalidPolicyException();
            
            return descendents.Single(baseDelegate);
        }

        GetBase(parent.Inbound).ReplaceWith(child.Inbound.Elements());
        GetBase(parent.Backend).ReplaceWith(child.Backend.Elements());
        GetBase(parent.Outbound).ReplaceWith(child.Outbound.Elements());
        GetBase(parent.OnError).ReplaceWith(child.OnError.Elements());

        return parent;
    }
}
