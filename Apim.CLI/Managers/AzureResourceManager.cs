using Semifinals.Apim.CLI.Models;

namespace Semifinals.Apim.CLI.Managers;

/// <summary>
/// Manager to fulfil deploying custom policies to Azure.
/// </summary>
public class AzureResourceManager
{
    private readonly ArmClient _client;

    public string ResourceGroupName { get; }

    public string ApimServiceName { get; }

    public string ApiId { get; }

    public AzureResourceManager(string resourceGroupName, string apimServiceName, string apiId)
    {
        _client = new(new DefaultAzureCredential());

        ResourceGroupName = resourceGroupName;
        ApimServiceName = apimServiceName;
        ApiId = apiId;
    }

    public async Task Deploy(IEnumerable<Trigger> triggers)
    {
        // Get APIM resource
        var subscription = await _client.GetDefaultSubscriptionAsync();
        ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(ResourceGroupName);
        ApiManagementServiceResource apim = await resourceGroup.GetApiManagementServiceAsync(ApimServiceName);

        // Get associated API
        ApiResource api = await apim.GetApiAsync(ApiId);

        // Update API operation policies
        var updateTasks = new List<Task<Response<ApiOperationResource>>>();
        foreach (var op in api.GetApiOperations())
        {
            var trigger = triggers.FirstOrDefault(trigger => trigger.Name == op.Data.Name);
            // TODO: ^^^ Check if correct ^^^
            if (trigger is null)
            {
                Console.WriteLine($"Warn - No policies found to apply to {op.Data.DisplayName} ({op.Data.Name})");
                continue;
            }

            ApiOperationPatch patch = new()
            {
                Policies = trigger.Policy.ToString()
                // TODO: Check if this expects ALL to be provided, and if so grab from operation.Data
            };

            var task = op.UpdateAsync(ETag.All, patch);
            updateTasks.Add(task);
        }

        await Task.WhenAll(updateTasks);
    }
}
