
#pragma warning disable IL2026, IL3050

#:package DotNetEnv@3.1.1
#:package Microsoft.Agents.AI@1.0.0-preview.260209.1
#:package Microsoft.Extensions.AI.OpenAI@10.1.1-preview.1.25612.2

using DotNetEnv;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Microsoft.Extensions.AI;
using Microsoft.Agents.AI;

Env.Load();

var API_KEY = Environment.GetEnvironmentVariable("REKA_API_KEY")!;
var baseUrl = "https://api.reka.ai/v1";
var modelName = "reka-flash-research";

// var API_KEY = Environment.GetEnvironmentVariable("OPENAI_API_KEY")!;
// var baseUrl = "https://api.openai.com/v1";
// var modelName = "gpt-5";

// var API_KEY = Environment.GetEnvironmentVariable("CLAUDE_API_KEY")!;
// var baseUrl = "https://api.anthropic.com/v1";
// var modelName = "claude-opus-4-6";

// var API_KEY = "ollama";
// var baseUrl = "http://192.168.2.11:11434/v1";
// var modelName = "llama3.1:8b";


IChatClient chatClient = new ChatClient(modelName, new ApiKeyCredential(API_KEY), new OpenAIClientOptions
{
    Endpoint = new Uri(baseUrl)
}).AsIChatClient();

// Create a JSON schema from the TechEventsResponse type for structured output
var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
{
    TypeInfoResolver = new DefaultJsonTypeInfoResolver()
};
JsonElement schema = AIJsonUtilities.CreateJsonSchema(typeof(TechEventsResponse), serializerOptions: jsonOptions);

ChatOptions chatOptions = new()
{
    ResponseFormat = Microsoft.Extensions.AI.ChatResponseFormat.ForJsonSchema(
        schema: schema,
        schemaName: "TechEventsResponse",
        schemaDescription: "A list of tech events with name, location, and date")
};

AIAgent agent = new ChatClientAgent(chatClient, new ChatClientAgentOptions
{
    Name = "user",
    ChatOptions = chatOptions
});

string prompt = "Give me 3 major tech events happening in the USA between January and June 2026";

var response = await agent.RunAsync(prompt);
var result = response.Deserialize<TechEventsResponse>(jsonOptions);

Console.WriteLine("Tech Events:");
foreach (var evt in result.Events)
{
    Console.WriteLine($"  - {evt.Name} | {evt.Location} | {evt.Date}");
}

public class TechEvent
{
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string Date { get; set; }
}

public class TechEventsResponse
{
    public required List<TechEvent> Events { get; set; } = new List<TechEvent>();
}
