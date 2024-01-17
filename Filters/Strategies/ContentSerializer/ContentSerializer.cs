namespace Semifinals.Filters.Strategies.ContentSerializer;

public class ContentSerializerProvider
{
    public static IContentSerializer GetSerializer(string contentType)
    {
        return contentType switch
        {
            "application/json" => new JsonContentSerializer(),
            _ => throw new NotSupportedException(
                $"Content type {contentType} is not supported."),
        };
    }
}
