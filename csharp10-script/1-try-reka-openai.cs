
#:package DotNetEnv@3.1.1
#:package OpenAI@2.8.0

using DotNetEnv;
using OpenAI.Chat;
using OpenAI;
using System.ClientModel;

Env.Load();

// var API_KEY = Environment.GetEnvironmentVariable("REKA_API_KEY")!;
// var baseUrl = "https://api.reka.ai/v1";
// var modelName = "reka-flash-research";

var API_KEY = Environment.GetEnvironmentVariable("OPENAI_API_KEY")!;
var baseUrl = "https://api.openai.com/v1";
var modelName = "gpt-5";

var openAiClient = new OpenAIClient(new ApiKeyCredential(API_KEY), new OpenAIClientOptions
{
    Endpoint = new Uri(baseUrl)
});

var client = openAiClient.GetChatClient(modelName);

string prompt = "Suggest 3 tech event, with a AI focus, that I can attend in Canada";

var completion = await client.CompleteChatAsync(
    new List<ChatMessage>
    {
        new UserChatMessage(prompt)
    }
);

var generatedText = completion.Value.Content[0].Text;

Console.WriteLine($" Result: \n{generatedText}");
