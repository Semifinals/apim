namespace Semifinals.Filters.Strategies.ContentSerializer;

public interface IContentSerializer
{
    Task<T> DeserializeAsync<T>(Stream stream) where T : class;

    Task<T> DeserializeAsync<T>(string body) where T : class;

    Task SerializeAsync<T>(Stream stream, T body) where T : class;

    Task<string> SerializeAsync<T>(T body) where T : class;
}
