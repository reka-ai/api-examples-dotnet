
#:package DotNetEnv@3.1.1
#:package OpenAI@2.8.0

using DotNetEnv;
using OpenAI.Chat;
using OpenAI;
using System.ClientModel;

Env.Load();

var REKA_API_KEY = Environment.GetEnvironmentVariable("REKA_API_KEY")!; 
var baseUrl = "https://api.reka.ai/v1";

var openAiClient = new OpenAIClient(new ApiKeyCredential(REKA_API_KEY), new OpenAIClientOptions
{
    Endpoint = new Uri(baseUrl)
});

var client = openAiClient.GetChatClient("reka-flash-research");

string prompt = "Suggest 3 tech event, with a AI focus, that I can attend in Canada";

var completion = await client.CompleteChatAsync(
    new List<ChatMessage>
    {
        new UserChatMessage(prompt)
    }
);

var generatedText = completion.Value.Content[0].Text;

Console.WriteLine($" Result: \n{generatedText}");
