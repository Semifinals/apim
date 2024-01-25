using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Fragments;

public class Fragment
{
    public string Id { get; }
    
    public XElement Data { get; protected set; }

    public Fragment(string id)
    {
        Id = id;
        Data = new XIncludeFragment(id);
    }

    public Fragment(XIncludeFragment data)
    {
        Id = data.FragmentId;
        Data = data;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}
