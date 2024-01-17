namespace Semifinals.Filters.Extensions;

public static class IHeaderDictionaryExtensions
{
    /// <summary>
    /// Remove the existing value(s) and set the header to the given value.
    /// </summary>
    /// <param name="headers">The header dictionary</param>
    /// <param name="key">The key to set</param>
    /// <param name="value">The value to set</param>
    public static void Set(this IHeaderDictionary headers, string key, string value)
    {
        headers.Remove(key);
        headers.Add(key, value);
    }
}
