namespace Semifinals.Apim.Nodes;

public class XPath : XElement, IXValidateParametersChild
{
    public XPath(
        string name,
        EXPathSpecifiedParameterAction specifiedAction)
        : base("path")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction));
    }
}

public enum EXPathSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface IXPathChild { }
