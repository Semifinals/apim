﻿using Semifinals.Apim.Policies;

namespace Semifinals.Apim.Attributes;

/// <summary>
/// Adds a valid response body and status code to the endpoint.
/// </summary>
public class ResponseBodyAttribute : OpenApiResponseWithBodyAttribute, IPolicyAttribute
{
    public int Priority { get; init; } = int.MaxValue;

    public Policy Policy { get; }

    public ResponseBodyAttribute(
        HttpStatusCode statusCode,
        string contentType,
        Type bodyType)
        : base(statusCode, contentType, bodyType)
    {
        Policy = new ResponseBodyPolicy(statusCode, contentType);
    }
}