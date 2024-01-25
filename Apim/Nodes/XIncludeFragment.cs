namespace Semifinals.Apim.Nodes;

public class XIncludeFragment : XElement
{
    public string FragmentId { get; }
    
    public XIncludeFragment(string fragmentId) : base("include-fragment")
    {
        FragmentId = fragmentId;
        
        Add(new XAttribute("fragment-id", fragmentId));
    }
}
