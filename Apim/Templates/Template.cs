namespace Semifinals.Apim.Templates;

public class Template
{
    private readonly XElement _data = new XElement("template");
    
    public IEnumerable<XElement> Data
    {
        get { return _data.Elements(); }
    }

    public void Add(params XElement[] element) =>
        _data.Add(element);

    public override string ToString()
    {
        return string.Join('\n', Data.Select(e => e.ToString()));
    }
}
