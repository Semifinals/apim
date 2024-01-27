using Semifinals.Apim.Nodes;

namespace Semifinals.Apim.Fragments;

// Current implementation is identical to the link below, and needs to be
// rewritten to align with Semifinals/guardian before it can be used elsewhere.
// https://www.styra.com/blog/policy-as-code-with-azure-api-management-apim-and-opa/

public sealed class AuthorizeFragment : Fragment
{
    public AuthorizeFragment() : base()
    {
        string authorizerUrl = "https://example.com";

        var body = JsonConvert.SerializeObject(
            new JObject(
                new JProperty("input", new JObject(
                    new JProperty("request", new JObject(
                        new JProperty("headers", new JObject(
                            new JProperty("host",
                                "{{context.Request.Url.Host}}"),
                            new JProperty("authorization",
                                "{{context.Variables[\"authorization\"]}}"))),
                        new JProperty("parsed_path",
                            "{{context.Variables[\"uriSegments\"]}}"),
                        new JProperty("path",
                            "{{context.Request.Url.Path}}"),
                        new JProperty("port",
                            "{{context.Request.Url.Port}}"),
                        new JProperty("scheme",
                            "{{context.Request.Url.Scheme}}"),
                        new JProperty("query_string",
                            "{{context.Request.Url.QueryString}}"),
                        new JProperty("url",
                            "{{context.Request.Url.ToString()}}"),
                        new JProperty("method",
                            "{{context.Request.Method}}"),
                        new JProperty("request_id",
                            "{{context.Variables[\"requestId\"]}}"),
                        new JProperty("body",
                            "{{context.Variables[\"requestBody\"] ?? null}}"))),
                    new JProperty("apim_name",
                        "{{context.Variables[\"serviceName\"]}}"),
                    new JProperty("original_url",
                        "{{context.Variables[\"originalUrl\"]}}")))));

        Data.Add(
            // Set variables for policy
            new XSetVariable("requestId",
                "@(context.RequestId)"),
            new XSetVariable("serviceName",
                "@(context.Deployment.ServiceName)"),
            new XSetVariable("originalUrl",
                "@(context.Request.OriginalUrl.ToString())"),
            new XSetVariable("authorization",
                @"@(context.Request.Headers.GetValueOrDefault(""Authorization""))"),
            new XSetVariable("uriSegments",
                "@(JsonConvert.SerializeObject(new Uri(context.Request.Url.ToString()).Segments))"),
            new XChoose(
                new XWhen("@((bool)context.Request.HasBody)",
                    new XSetVariable("requestBody",
                        "@(context.Request.Body.As<string>(preserveContent: true))"))),
            // Submit auth request
            new XSendRequest("new", "response", 10, false,
                new XSetUrl(authorizerUrl),
                new XSetMethod("POST"),
                new XSetBody("liquid", body)),
            // Handle failed request
            new XChoose(
                new XWhen(@"@(((IResponse)context.Variables[""response""]).StatusCode != 200)",
                    new XReturnResponse(
                        new XSetStatus(
                            @"@(((IResponse)context.Variables[""response""]).StatusCode)",
                            @"@(((IResponse)context.Variables[""response""]).StatusReason)")))),
            // Forbid results where no result exists
            new XSetVariable("decisionJson",
                @"@(((IResponse)context.Variables[""response""]).Body.As<JObject>())"),
            new XChoose(
                new XWhen(@"@(!((JObject)context.Variables[""decisionJson""]).ContainsKey(""result""))",
                    new XReturnResponse(
                        new XSetStatus(403, "Forbidden")))),
            // Forbid results where result is not true
            new XSetVariable("allow",
                @"@(((JObject)context.Variables[""decisionJson""])[""result""].ToString())"),
            new XChoose(
                new XWhen(@"@(((string)context.Variables[""allow""]).ToLower() != ""true"")",
                    new XReturnResponse(
                        new XSetStatus(403, "Forbidden")))));
    }
}
