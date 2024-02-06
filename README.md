# Apim

A package for managing gateway policies for distributed systems.

## Usage

```cs
[FunctionName(nameof(Ping)]
[Authorize]
public async Task<IActionResult> Ping(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ping")] HttpRequest req)
{
    // Only authorized requests reach here :)
    return new OkObjectResult("Pong!");
}
```

In this example, Apim's `[Authorize]` attribute is being used to add an authorization policy to Azure API Management, preventing any unauthorized request from reaching the Azure Functions app. The function app is secured using a function key which the gateway accesses through a managed identity, meaning the gateway is the only way to trigger requests.

Because the request never reaches the function app, there's also no cold start issue for an invalid request! This becomes dependent on the SKU of the gateway rather than the services.

## Motivation

Effectively maintaining Azure API Management to keep it up to date with the needs of the downstream products can be difficult since it effectively involves tightly coupling the logic of multiple services to the gateway. While the gateway does loosely couple the backend implementations from users hitting the gateway, the fact that it can be handling validation, authentication, and other important aspects of the backend service can make things challenging to maintain.

This package intends to give the power back to the services. Definitions for policies for the gateway are added to the individual endpoints with attributes so the gateway can be automatically updated during the service's deployment pipeline. Additionally, it aids in effective API documentation as much of the API Management's features work with OpenAPI specs, meaning use of this package also results in better documented code.
