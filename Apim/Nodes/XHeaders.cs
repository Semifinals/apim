namespace Semifinals.Apim.Nodes;

public class XHeaders : XElement, IXValidateParametersChild
{
    public XHeaders(
        string name,
        EXHeadersSpecifiedParameterAction specifiedAction,
        EXHeadersUnspecifiedParameterAction unspecifiedAction)
        : base("headers")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction));
    }
}

public enum EXHeadersSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum EXHeadersUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface IXHeadersChild { }
