namespace Semifinals.Apim.Nodes;

public class XValidateParameters : XElement
{
    public XValidateParameters(
        EXValidateParametersSpecifiedParameterAction specifiedAction,
        EXValidateParametersUnspecifiedParameterAction unspecifiedAction,
        params IXValidateParametersChild[] nodes)
        : base("validate-parameters")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }
    
    public XValidateParameters(
        EXValidateParametersSpecifiedParameterAction specifiedAction,
        EXValidateParametersUnspecifiedParameterAction unspecifiedAction,
        string errorsVariableName,
        params IXValidateParametersChild[] nodes)
        : base("validate-parameters")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}

public enum EXValidateParametersSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum EXValidateParametersUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface IXValidateParametersChild { }
