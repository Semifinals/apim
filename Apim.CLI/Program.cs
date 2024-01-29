using Semifinals.Apim.Attributes;
using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        // TODO: Determine assembly path from args
        Console.WriteLine(string.Join(' ', args));
        var assembly = Assembly.LoadFrom("");

        var triggers = assembly.GetTypes()
            // Get all unique policies on each trigger
            .SelectMany(type => type
                .GetMethods()
                .Select(method => (
                    Name: type.FullName + "." + method.Name,
                    Method: method,
                    Policies: method
                        .GetCustomAttributes(typeof(PolicyAttribute), true)
                        .Select(attribute => ((PolicyAttribute)attribute).Policy)
                        .DistinctBy(policy => policy.GetType().Name)
                        .OrderBy(policy => policy.Priority)
                        .Reverse())))
            // Filter out methods that have no policies
            .Where(trigger => trigger.Policies.Any())
            // Aggregate policies using <base />
            .Select(trigger => (
                trigger.Name,
                trigger.Method,
                Policy: trigger.Policies.Reverse().Aggregate((low, high) =>
                {
                    high.Inbound.ReplaceNodes(
                        high.Inbound.Elements().SelectMany((element, i) =>
                            element.Name == new XBase().Name
                                ? low.Inbound.Elements()
                                : new[] { element }));

                    // TODO: Fix above to handle nested <base /> uses
                    // TODO: Apply this process to all layers, not just inbound
                    // TODO: Clean up this Aggregate to not need {} (optional)

                    return high;
                })));

        // TODO: Apply generated trigger policies
    }
}
