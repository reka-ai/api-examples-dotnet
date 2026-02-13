
#:package DotNetEnv@3.1.1
#:package Microsoft.Agents.AI@1.0.0-preview.260209.1
#:package Microsoft.Extensions.AI.OpenAI@10.1.1-preview.1.25612.2

using DotNetEnv;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using Microsoft.Extensions.AI;
using Microsoft.Agents.AI;

Env.Load();

var REKA_API_KEY = Environment.GetEnvironmentVariable("REKA_API_KEY")!;
var baseUrl = "https://api.reka.ai/v1";

IChatClient chatClient = new ChatClient("reka-flash-research", new ApiKeyCredential(REKA_API_KEY), new OpenAIClientOptions
{
    Endpoint = new Uri(baseUrl)
}).AsIChatClient();

AIAgent agent = new ChatClientAgent(chatClient,
    instructions: "You are a helpful assistant that recommends tech events.",
    name: "RekaAgent");

string prompt = "Give me 3 major tech events happening in the USA between January and June 2026";

Console.WriteLine(await agent.RunAsync(prompt));
