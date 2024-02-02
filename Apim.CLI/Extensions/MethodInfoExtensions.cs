using Semifinals.Apim.Attributes;
using Semifinals.Apim.CLI.Models;
using Semifinals.Apim.Policies;

namespace Semifinals.Apim.CLI.Extensions;

public static class MethodInfoExtensions
{
    public static bool IsFunction(this MethodInfo methodInfo) => methodInfo
        .GetCustomAttributes<FunctionNameAttribute>()
        .Any();

    public static string ExtractFunctionName(this MethodInfo methodInfo) => methodInfo
        .GetCustomAttributes<FunctionNameAttribute>()
        .First().Name;

    public static Policy ExtractPolicy(this MethodInfo methodInfo) => AppDomain
        .CurrentDomain
        .GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(type =>
            typeof(IPolicyAttribute).IsAssignableFrom(type) &&
            type.IsClass &&
            !type.IsAbstract)
        .SelectMany(attribute =>
            (IEnumerable<IPolicyAttribute>)
            methodInfo.GetCustomAttributes(attribute))
        .OrderBy(attribute => attribute.Priority)
        .Select(attribute => attribute.Policy)
        .Aggregate(
            new DefaultPolicy() as Policy,
            (p, c) => p.Nest(c));

    public static Trigger ParseTrigger(this MethodInfo methodInfo)
    {
        var name = methodInfo.ExtractFunctionName();
        var policy = methodInfo.ExtractPolicy();
        return new Trigger(name, policy);
    }
}
