namespace Semifinals.Filters.Policies.Fragments;

public class Fragment
{
    public XElement Data { get; protected set; }
    
    public Fragment()
    {
        Data = new XElement("fragment");
    }

    public Fragment(XElement data)
    {
        Data = data;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}
