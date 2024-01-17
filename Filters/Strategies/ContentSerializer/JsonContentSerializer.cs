using Semifinals.Filters.Extensions;

namespace Semifinals.Filters.Strategies.ContentSerializer;

public class JsonContentSerializer : IContentSerializer
{
    public async Task<T> DeserializeAsync<T>(Stream stream)
        where T : class
    {
        try
        {
            var obj = await JsonSerializer.DeserializeAsync<T>(stream);

            if (obj is not null)
                return obj;
            else
                throw new Exception();
        }
        catch (Exception)
        {
            throw new SerializationFailureException();
        }
    }

    public async Task<T> DeserializeAsync<T>(string body)
        where T : class
    {
        using var stream = new MemoryStream();
        stream.Write(Encoding.UTF8.GetBytes(body));
        stream.Position = 0;

        return await DeserializeAsync<T>(stream);
    }

    public async Task SerializeAsync<T>(Stream stream, T body)
        where T : class
    {
        try
        {
            await JsonSerializer.SerializeAsync<T>(stream, body);
        }
        catch (Exception)
        {
            throw new SerializationFailureException();
        }
    }

    public async Task<string> SerializeAsync<T>(T body)
        where T : class
    {
        try
        {
            using var stream = new MemoryStream();

            await JsonSerializer.SerializeAsync<T>(stream, body);

            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        catch (Exception)
        {
            throw new SerializationFailureException();
        }
    }
}
