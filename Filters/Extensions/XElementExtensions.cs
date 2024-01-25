using Semifinals.Filters.Policies.Nodes;

namespace Semifinals.Filters.Extensions;

public static class XElementExtensions
{
    /// <summary>
    /// Check if an element type exists inside an XElement instance.
    /// </summary>
    public static bool HasElement(this XElement element, string type)
    {
        return element.Elements(type).FirstOrDefault() != null;
    }

    /// <summary>
    /// Add a base element for a policy if it isn't already present.
    /// </summary>
    public static XElement AddBaseIfNotExists(this XElement element)
    {
        if (!element.HasElement("base"))
            element.Add(new XBase());

        return element;
    }
}
