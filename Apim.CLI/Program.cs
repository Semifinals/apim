using Semifinals.Apim.CLI.Exceptions;
using Semifinals.Apim.CLI.Extensions;
using Semifinals.Apim.CLI.Managers;

namespace Semifinals.Apim.CLI;

public class Program
{
    public static async void Main(string[] args)
    {
        try
        {
            // Parse arguments
            if (args.Length == 0) throw new ArgumentException("No arguments provided");
            else if (args.Length < 4) throw new ArgumentException("Not all arguments were provided");

            var resoureGroupName = args[0];
            var apimServiceName = args[1];
            var apiId = args[2];

            var path = string.Join(' ', args[3..])
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
                    .Where(methodInfo => methodInfo.IsFunction())
                    .Select(methodInfo => methodInfo.ParseTrigger()));

            // Apply generated trigger policies
            Console.WriteLine("Deploying updated policies to APIM...");
            AzureResourceManager arm = new(resoureGroupName, apimServiceName, apiId);
            await arm.Deploy(triggers);

            // Log success if program completed without exception
            Console.WriteLine("Success!");
        }
        catch (ArgumentException ex)
        {
            Console.Error.WriteLine($"Deployment failed due to an ArgumentException: {ex.Message}");
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
