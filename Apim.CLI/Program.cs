using Semifinals.Apim.Attributes;
using Semifinals.Apim.CLI.Exceptions;
using Semifinals.Apim.CLI.Extensions;

namespace Semifinals.Apim.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Loading assembly...");
            // TODO: Determine assembly path from args
            Console.WriteLine("DEBUG: " + string.Join(' ', args));
            var assembly = Assembly.LoadFrom("");

            Console.WriteLine("Generating trigger policies...");
            var triggers = assembly.GetTypes()
                // Get all unique policies on each trigger
                .SelectMany(type => type
                    .GetMethods()
                    .Select(method => (
                        Name: type.FullName + "." + method.Name,
                        Method: method,
                        Policies: method
                            .GetCustomAttributes(typeof(PolicyAttribute), true)
                            .OfType<PolicyAttribute>()
                            .Select(attribute => attribute.Policy)
                            .DistinctBy(policy => policy.GetType().Name)
                            .OrderBy(policy => policy.Priority))))
                // Filter out methods that have no policies
                .Where(trigger => trigger.Policies.Any())
                // Aggregate policies using <base />
                .Select(trigger => (
                    trigger.Name,
                    trigger.Method,
                    Policy: trigger.Policies.Aggregate((p, c) => p.Nest(c))));

            // TODO: Apply generated trigger policies

            Console.WriteLine("Successfully run!");
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Failed because could not find assembly");
        }
        catch (InvalidPolicyException)
        {
            Console.Error.WriteLine("Failed due to an invalid policy.");
        }
    }
}
