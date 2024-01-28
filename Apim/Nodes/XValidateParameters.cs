namespace Semifinals.Apim.Nodes;

public class XValidateParameters : XElement
{
    public XValidateParameters(
        XValidateParametersSpecifiedParameterAction specifiedAction,
        XValidateParametersUnspecifiedParameterAction unspecifiedAction,
        params XValidateParametersChild[] nodes)
        : base("validate-parameters")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            nodes);
    }
    
    public XValidateParameters(
        XValidateParametersSpecifiedParameterAction specifiedAction,
        XValidateParametersUnspecifiedParameterAction unspecifiedAction,
        string errorsVariableName,
        params XValidateParametersChild[] nodes)
        : base("validate-parameters")
    {
        Add(
            new XAttribute("specified-parameter-action", specifiedAction),
            new XAttribute("unspecified-parameter-action", unspecifiedAction),
            new XAttribute("errors-variable-name", errorsVariableName),
            nodes);
    }
}

public enum XValidateParametersSpecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public enum XValidateParametersUnspecifiedParameterAction
{
    Ignore,
    Prevent,
    Detect
}

public interface XValidateParametersChild { }
