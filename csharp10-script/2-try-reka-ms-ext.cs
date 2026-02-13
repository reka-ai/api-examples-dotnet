
#:package DotNetEnv@3.1.1
#:package Microsoft.Extensions.AI.OpenAI@10.1.1-preview.1.25612.2

using DotNetEnv;
using System.ClientModel;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Chat;

Env.Load();

var REKA_API_KEY = Environment.GetEnvironmentVariable("REKA_API_KEY")!;
var baseUrl = "https://api.reka.ai/v1";
var modelName = "reka-flash-research";

IChatClient client = new ChatClient(modelName, new ApiKeyCredential(REKA_API_KEY), new OpenAIClientOptions
{
    Endpoint = new Uri(baseUrl)
}).AsIChatClient();

string prompt = "Suggest 3 tech event, with a AI focus, that I can attend in Canada";

Console.WriteLine(await client.GetResponseAsync(prompt));