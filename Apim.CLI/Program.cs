using Semifinals.Apim.Attributes;
using Semifinals.Apim.CLI.Exceptions;
using Semifinals.Apim.CLI.Extensions;
using Semifinals.Apim.Policies;

namespace Semifinals.Apim.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Parse arguments
            if (args.Length == 0)
                throw new ArgumentException();

            var path = string.Join(' ', args)
                .Trim()
                .Replace("'", "")
                .Replace("\"", "");
            
            // Load assembly
            Console.WriteLine("Loading assembly...");
            var assembly = Assembly.LoadFrom(path);

            // Generate trigger policies
            Console.WriteLine("Generating trigger policies...");
            var triggers = assembly.GetExportedTypes()
                .SelectMany(type => type
                    .GetMethods()
                    .Where(method => method
                        .GetCustomAttributes<FunctionNameAttribute>()
                        .Any())
                    .Select(method => KeyValuePair.Create(
                        method
                            .GetCustomAttributes<FunctionNameAttribute>()
                            .First().Name,
                        method
                            .GetCustomAttributes<PolicyAttribute>()
                            .Select(attribute => attribute.Policy)
                            .OrderBy(policy => policy.Priority)
                            .Aggregate(
                                new DefaultPolicy() as Policy,
                                (p, c) => p.Nest(c)))))
                .ToDictionary(kvp => kvp);
            
            // TODO: Apply generated trigger policies

            Console.WriteLine("Success!");
        }
        catch (ArgumentException)
        {
            Console.Error.WriteLine("You must provide the absolute path to the assembly");
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("Failed because could not find assembly");
        }
        catch (InvalidPolicyException)
        {
            Console.Error.WriteLine("Failed due to an invalid policy");
        }
    }
}
