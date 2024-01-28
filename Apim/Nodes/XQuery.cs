namespace Semifinals.Apim.Nodes;

public class XQuery : XElement, IXValidateParametersChild
{
    public XQuery(
        string name,
        EXQuerySpecifiedParameterAction specifiedAction,
        EXQueryUnspecifiedParameterAction unspecifiedAction)
        : base("query")
    {
        Add(
            new XAttribute("name", name),
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction));
    }
}

public enum EXQuerySpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum EXQueryUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface IXQueryChild { }
