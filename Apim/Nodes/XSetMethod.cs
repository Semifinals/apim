namespace Semifinals.Apim.Nodes;

public class XSetMethod : XElement
{
    public XSetMethod(string method) : base("set-method")
    {
        Add(method);
    }
}
