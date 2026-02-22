
#:package DotNetEnv@3.1.1

using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

Env.Load();

var API_KEY = Environment.GetEnvironmentVariable("REKA_API_KEY")!;
var baseUrl = "https://api.reka.ai/v1/chat/completions";
var modelName = "reka-flash-research";

// var API_KEY = "ollama";
// var baseUrl = "http://127.0.0.1:11434/v1/chat/completions";
// var modelName = "llama3.1:8b";

using var httpClient = new HttpClient();
httpClient.Timeout = Timeout.InfiniteTimeSpan;

var requestJson = new JsonObject
{
    ["model"] = modelName,
    ["messages"] = new JsonArray(
        new JsonObject
        {
            ["role"] = "user",
            ["content"] = "Suggest 3 tech event, with a AI focus, that I can attend in the United States"
        }
    ),
    ["response_format"] = GetResponseFormat(),
    ["research"] = new JsonObject
    {
        ["web_search"] = new JsonObject
        {
            ["allowed_domains"] = new JsonArray("sessionize.com", "microsoft.com", "github.com", "nvidia.com")
        }
    }
};

var jsonPayload = requestJson.ToJsonString();

using var request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
request.Headers.Add("Authorization", $"Bearer {API_KEY}");
request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

try
{
    var response = await httpClient.SendAsync(request);

    var responseContent = await response.Content.ReadAsStringAsync();

    if (response.IsSuccessStatusCode)
    {
        var jsonDocument = JsonDocument.Parse(responseContent);

        var contentString = jsonDocument.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        Console.WriteLine(contentString);
    }
    else
    {
        Console.WriteLine($"Error: {response.StatusCode}");
        Console.WriteLine(responseContent);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}

static JsonNode GetResponseFormat()
{
    return new JsonObject
    {
        ["type"] = "json_schema",
        ["json_schema"] = new JsonObject
        {
            ["name"] = "tech_events_response",
            ["schema"] = new JsonObject
            {
                ["type"] = "object",
                ["properties"] = new JsonObject
                {
                    ["tech_events"] = new JsonObject
                    {
                        ["type"] = "array",
                        ["items"] = new JsonObject
                        {
                            ["type"] = "object",
                            ["properties"] = new JsonObject
                            {
                                ["name"] = new JsonObject { ["type"] = "string" },
                                ["location"] = new JsonObject { ["type"] = "string" },
                                ["date"] = new JsonObject { ["type"] = "string" }
                            }
                        }
                    }
                },
                ["required"] = new JsonArray("tech_events")
            }
        }
    };
}
