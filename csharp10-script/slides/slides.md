---
marp: true
theme: default
paginate: false
style: |
  @import url('https://fonts.googleapis.com/css2?family=Inter:wght@300;400;600;700&family=JetBrains+Mono:wght@400&display=swap');

  :root {
    --primary: #2276FF;
    --dark:    #2E2F2F;
    --muted:   #D5D0C1;
    --text:    #F1EEE7;
    --orange:  #FF7E4F;
    --green:   #66C7DB;
    --red:     #FF93ED;
  }

  /* Base — all slides dark */
  section {
    background: var(--dark);
    color: var(--text);
    font-family: 'Inter', KMR Waldenburg, sans-serif;
    font-weight: 300;
    font-size: 22px;
    padding: 40px 50px;
  }

  /* Header bar on content slides */
  section h2 {
    background: var(--primary);
    color: var(--text);
    margin: -40px -50px 30px -50px;
    padding: 14px 50px;
    font-size: 24px;
    font-weight: 600;
  }

  /* Slide number */
  section::after {
    color: var(--muted);
    font-size: 14px;
  }

  /* Title slides — same dark bg, different layout */
  section.title {
    justify-content: flex-start;
    padding-top: 90px;
  }
  section.title h1, section.title h2 {
    font-size: 64px;
    line-height: 1.1;
    border-left: 6px solid var(--primary);
    padding-left: 24px;
    margin-bottom: 20px;
    background: transparent;
    color: var(--text);
    margin-top: 0;
    padding-top: 0;
  }
  section.title p {
    color: var(--muted);
    font-size: 20px;
    padding-left: 30px;
  }
  section.title .tags {
    color: var(--primary);
    font-size: 16px;
    padding-left: 30px;
    margin-top: 20px;
  }
  section.title h3 {
    font-size: 26px;
    font-weight: 400;
    color: var(--muted);
    padding-left: 30px;
    margin-top: 0;
  }
  del { color: var(--muted); }

  /* Page tag (top-right, slide-specific) */
  .tag {
    float: right;
    background: var(--primary);
    color: var(--text);
    font-size: 13px;
    font-weight: bold;
    padding: 3px 12px;
    border-radius: 3px;
    margin-top: -6px;
  }

  /* Callout boxes — dark-friendly */
  .box-orange { background: rgba(255,126,79,0.15);  border-left: 4px solid var(--orange); padding: 12px 18px; margin: 12px 0; }
  .box-green  { background: rgba(102,199,219,0.15); border-left: 4px solid var(--green);  padding: 12px 18px; margin: 12px 0; }
  .box-red    { background: rgba(255,147,237,0.15); border-left: 4px solid var(--red);    padding: 12px 18px; margin: 12px 0; }
  .box-blue   { background: rgba(34,118,255,0.15);  border-left: 4px solid var(--primary); padding: 12px 18px; margin: 12px 0; }

  /* Two-column layout */
  .cols { display: grid; grid-template-columns: 1fr 1fr; gap: 16px; }

  /* Accent bullet rows */
  .row-g { border-left: 5px solid var(--green);  padding: 6px 14px; margin: 8px 0; }
  .row-o { border-left: 5px solid var(--orange); padding: 6px 14px; margin: 8px 0; }
  .row-r { border-left: 5px solid var(--red);    padding: 6px 14px; margin: 8px 0; }
  .row-m { border-left: 5px solid var(--muted);  padding: 6px 14px; margin: 8px 0; }
  .row-g strong, .row-o strong, .row-r strong, .row-m strong { display: block; }

  /* Tool definition cards */
  .tool-card { background: rgba(255,255,255,0.07); padding: 10px 16px; margin: 8px 0; border-radius: 4px; }
  .tool-card:nth-child(even) { background: rgba(255,255,255,0.12); }
  .tool-card strong { color: var(--primary); display: block; margin-bottom: 4px; }

  /* Code blocks */
  pre { background: var(--muted) !important; border-radius: 4px; font-size: 20px !important; color: var(--dark) !important; line-height: 1.5 !important; }
  code { font-family: 'JetBrainsMono Nerd Font', 'JetBrains Mono NF', 'JetBrains Mono', monospace; }

  /* Tables */
  table { width: 100%; border-collapse: collapse; font-size: 18px; }
  thead tr { background: var(--primary); color: var(--text); }
  thead th { padding: 8px 12px; text-align: left; }
  tbody tr:nth-child(even) { background: var(--muted); color: var(--dark); }
  tbody td { padding: 10px 12px; }
  tbody td:last-child { color: var(--muted); font-weight: bold; }
  tbody td:nth-child(2) { color: var(--primary); font-weight: bold; }
  tbody tr:nth-child(even) td:last-child { color: var(--dark); }

  /* Images */
  img[alt~="bottom-right"] {
  position: absolute;
  bottom: 30px;
  right: 30px; 
  height: 200px;
  width: 200px }

  img[alt~="reka-logo"] {
  position: relative;
  left: -20px; 
  height: 100px; }
---

<!-- _class: title -->

# Can we use AI<br>with .NET?

A practical tour of SDKs, ergonomics,
and the gotchas along the way.

![bottom-right](assets/confoo-can-we-use-ai-with-net-2026.png)

---

<!-- _class: title -->

## AI with .NET

```csharp
var process = Process.Start(new ProcessStartInfo
{
    FileName = "python",
    Arguments = "script.py",
    RedirectStandardOutput = true,
    UseShellExecute = false
})!;

Console.WriteLine(await process.StandardOutput.ReadToEndAsync());
await process.WaitForExitAsync();
```

---

## Agenda

- ### Context & setup

- ### 7 demos: One task. Done 7 different ways.

- ### Gotchas & wrap-up

---

<!-- _class: title -->

## Disclaimer

~~"Is Copilot-generated C# actually good?"~~

~~"Should I let AI write all my .NET code?"~~

~~"Which model is the best?"~~

We're just here to make an API call. 7 times.

<div class="box-blue">

**That said...** Check out 👉 bradygaster/squad

</div>

---

## The prompt we'll use

Same question. Different tool each time.

<div class="box-blue" style="font-size:24px; font-style:italic; padding: 20px 24px; margin: 16px 0;">

"Suggest 3 tech events with an AI focus that I can attend in Canada."

</div>

**What we're comparing:**
Setup complexity · Lines of code · Provider flexibility · Gotchas

GitHub: `link.reka.ai/dotnet`

![bottom-right](assets/QRcode_gh-reka-dotnet.jpg)

---

## Setup: .NET 10 file-based apps

**No `.csproj`. No `.sln`. No `bin/` or `obj/`.**

Each demo is a single `.cs` file — run it directly:

```bash
dotnet run 1-try-openai.cs
```

<div class="box-blue">

Zero project friction. Clone → add API key → run.

</div>

> Pro tip: devcontainer included — works in GitHub Codespaces with zero local setup.

---

## The tools — quick definitions

<div class="tool-card">
<strong>OpenAI SDK for .NET</strong>
Official SDK from OpenAI. Mirrors the API shape directly. Works with any OpenAI-compatible endpoint.
</div>

<div class="tool-card">
<strong>Microsoft.Extensions.AI</strong>
Microsoft's vendor-neutral abstraction layer. Defines <code>IChatClient</code>  swap providers without changing your call logic.
</div>

<div class="tool-card">
<strong>Microsoft AI Agent SDK</strong>
Multi-language framework built with the best of <code>Semantic Kernal</code> and <code>AutoGen</code>. Very new - still in preview.
</div>

<div class="tool-card">
<strong>Raw HttpClient</strong>
No AI SDK. You speak directly to the REST API using .NET's built-in HTTP client. Maximum portability.
</div>

---

## Demo 1 — OpenAI SDK

```csharp
#:package OpenAI@2.8.0

var client = new OpenAIClient(
    new ApiKeyCredential(API_KEY),
    new OpenAIClientOptions { Endpoint = new Uri(BASE_URL) });

var chat = client.GetChatClient(MODEL);

var completion = await chat.CompleteChatAsync(
    new List<ChatMessage> { ChatMessage.CreateUserMessage(prompt) });

Console.WriteLine(completion.Value.Content[0].Text);
```

---

## Demo 1 — OpenAI SDK · Key points

<div class="row-g"><strong>Familiar shape</strong>If you've used the OpenAI SDK in any language, this feels the same.</div>

<div class="row-g"><strong>OpenAI-compatible</strong>Change <code>BASE_URL</code> → works with Reka, Ollama, Azure OpenAI, and more.</div>

<div class="row-o"><strong>Vendor-shaped API</strong>Your code is coupled to OpenAI's types: <code>ChatMessage</code>, <code>Content[0].Text</code>…</div>

<div class="row-m"><strong>Good starting point</strong>Best choice if you're just getting started and don't need flexibility yet.</div>

---

## Demo 2 — Microsoft.Extensions.AI

```csharp
#:package Microsoft.Extensions.AI.OpenAI@10.1.1-preview.1.25612.2

IChatClient client = new OpenAIClient(
    new ApiKeyCredential(API_KEY),
    new OpenAIClientOptions { Endpoint = new Uri(BASE_URL) })
    .AsChatClient(MODEL);   // ← the one magic method

Console.WriteLine(await client.GetResponseAsync(prompt));
```

<div class="box-blue">

**The entire call is one line.** 23 lines total — the shortest file in the repo.

</div>

---

## Demo 2 — Microsoft.Extensions.AI · Key points

**`IChatClient` — the key abstraction**
Typed as `IChatClient`, not `OpenAIClient`. Swap the provider without touching your call logic.

```csharp
// Today: Reka
IChatClient client = new OpenAIClient(...).AsChatClient(MODEL);

// Tomorrow: Azure OpenAI — only this line changes:
IChatClient client = new AzureOpenAIClient(...).AsChatClient(MODEL);

// Your call code is identical either way:
Console.WriteLine(await client.GetResponseAsync(prompt));
```

<div class="box-green">

Great default for most apps. Low ceremony, high flexibility.

</div>

---

## Demo 3 — Microsoft AI Agent SDK

```csharp
#:package Microsoft.Agents.AI@1.0.0-preview.260209.1
#:package Microsoft.Extensions.AI.OpenAI@10.1.1-preview.1.25612.2

IChatClient chatClient = new OpenAIClient(...)
    .AsChatClient(MODEL);

AIAgent agent = new ChatClientAgent(
    chatClient,
    instructions: "You are a helpful assistant that recommends tech events.",
    name: "RekaAgent");

Console.WriteLine(await agent.RunAsync(prompt));
```

---

## Demo 3 — Microsoft AI Agent SDK · Key points

**Built on top of MEA — not a replacement.**

What the Agent SDK adds:

- System instructions baked into the agent — not per-call
- `RunAsync` — a higher-level concept than "send a message"

<div class="box-orange">

**Preview:** `1.0.0-preview.260209.1` — date-stamped versioning (Feb 9, 2026).

</div>

---

## Demo 4 — Agent SDK + Structured Output

```csharp
#pragma warning disable IL2026, IL3050  // ← we'll come back to this

var schema  = AIJsonUtilities.CreateJsonSchema(typeof(TechEventsResponse));
var options = new ChatOptions {
    ResponseFormat = ChatResponseFormat.ForJsonSchema(schema, strictEnabled: true)
};

var response = await agent.RunAsync(prompt, options);
var result   = response.Deserialize<TechEventsResponse>(jsonOptions);
foreach (var evt in result.Events)
    Console.WriteLine($"  - {evt.Name} | {evt.Location} | {evt.Date}");
```

```csharp
public class TechEventsResponse { public List<TechEvent> Events { get; set; } }
public class TechEvent { public string Name, Location, Date { get; set; } }
```

---

## Demo 4 — Structured Output · Key points

- **Define a C# type → get typed data back. No string parsing.**

<div class="box-orange">

`#pragma warning disable IL2026, IL3050`

`CreateJsonSchema()` uses reflection. In a trimmed/NativeAOT build this can break.

</div>

- **Provider portability**

```csharp
var baseUrl = "https://api.reka.ai/v1";         var model = "reka-flash-research";
// var baseUrl = "https://api.openai.com/v1";    var model = "gpt-5";
// var baseUrl = "...anthropic.com/v1";          var model = "claude-opus-4-6";
// var baseUrl = "http://localhost:11434/v1";     var model = "llama3.1:8b";
```

<div class="box-green">Same code. Any OpenAI-compatible provider.</div>

---

## Demo 5 — OpenAI + Structured Output

```csharp
#pragma warning disable OPENAI001  // experimental API

var client    = new ResponsesClient(MODEL, new ApiKeyCredential(API_KEY));
var webSearch = ResponseTool.CreateWebSearchTool(
    searchContextSize: ResponseWebSearchContextSize.High,
    allowedDomains: ["sessionize.com", "microsoft.com", "github.com"]);

var options = new ResponseCreationOptions();
options.Tools.Add(webSearch);

var response = await client.CreateResponseAsync(prompt, options);
Console.WriteLine(response.Value.GetOutputText());
```

<div class="box-red">

Only works with OpenAI.

</div>

---

## Demo 5 — OpenAI Responses API · Key points


<div class="cols">

<div class="box-green">

**Power**
- Real-time web search built in
- Domain allow-list for grounding
- `ResponsesClient` = newest OpenAI API
- Results can cite sources

</div>

<div class="box-red">

**Lock-in**
- Proprietary — OpenAI only
- `OPENAI001` = experimental, can change
- No Reka, Ollama, or Azure support
- Trade: power for portability

</div>

</div>

---

## Demo 6 — Raw HttpClient (no AI SDK)

```csharp
#:package DotNetEnv@3.1.1   // only dependency

var httpClient = new HttpClient();
httpClient.Timeout = Timeout.InfiniteTimeSpan;         // ← don't skip this!
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", API_KEY);

var request = new ChatRequest(MODEL, [new ChatMessage("user", prompt)]);
var json = JsonSerializer.Serialize(request, ChatRequestContext.Default.ChatRequest);
var resp = await httpClient.PostAsync(BASE_URL + "/chat/completions",
    new StringContent(json, Encoding.UTF8, "application/json"));

var doc = JsonDocument.Parse(await resp.Content.ReadAsStringAsync());
Console.WriteLine(doc.RootElement
    .GetProperty("choices")[0].GetProperty("message")
    .GetProperty("content").GetString());
```

---

## Demo 6 — Raw HttpClient · Key points

<div class="box-red">

**important gotcha:**

`httpClient.Timeout = Timeout.InfiniteTimeSpan;`

Default timeout is 100s. AI inference can take longer. It **silently** kills your request.

</div>

Source-generated JSON serialization (AOT-friendly):

```csharp
[JsonSerializable(typeof(ChatRequest))]
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
internal partial class ChatRequestContext : JsonSerializerContext { }
```

**The punchline:** Works with any OpenAI-compatible API. Forever. No SDK version to update.

*Trade-off: you own the JSON, the headers, and the error handling. SDKs handle all of that for you.*

---

## Demo 7 — Raw HttpClient + Web Search + Structured Output

```csharp
var requestJson = new JsonObject
{
    ["model"] = modelName,
    ["messages"] = new JsonArray(
        new JsonObject { ["role"] = "user", ["content"] = prompt }
    ),
    ["response_format"] = GetResponseFormat(),   // JSON schema
    ["research"] = new JsonObject                
    {
        ["web_search"] = new JsonObject
        {
            ["allowed_domains"] = new JsonArray(
                "sessionize.com", "microsoft.com", "github.com")
        }
    }
};
var jsonPayload = requestJson.ToJsonString();
```

---

## Demo 7 — Raw HttpClient (advanced) · Key points

**Same zero-dependency approach as Demo 6 — but with Reka's advanced features.**

<div class="row-g"><strong>Web search + domain filtering</strong>Reka's <code>research.web_search</code> field grounds answers in live results from approved sites.</div>

<div class="row-g"><strong>Structured output via JSON schema</strong>No SDK support needed — just send the schema in <code>response_format</code> directly.</div>

<div class="box-orange">

**Gotcha: `JsonSerializerContext` disables reflection globally**
Defining a `JsonSerializerContext` in the same assembly prevents `JsonSerializer.Serialize`
from working on anonymous types. Fix: use `JsonObject`/`JsonNode` instead — no reflection needed.

</div>

---

## Lessons & Gotchas

<div class="row-r"><strong>HttpClient.Timeout</strong>The default 100s WILL silently kill slow AI responses. Set <code>InfiniteTimeSpan</code> or something reasonable.</div>

<div class="row-r"><strong>Preview packages</strong>MS Agent SDK and MEA.OpenAI are cutting-edge. Date-stamped versions. Expect breaking changes.</div>

<div class="row-o"><strong>Pragma warnings are informative</strong><code>OPENAI001</code>, <code>IL2026</code>, <code>IL3050</code> — they're telling you something real. Don't blindly suppress them.</div>

<div class="row-o"><strong>Lock-in is a spectrum</strong>Raw HTTP = zero lock-in. Responses API = maximum. Know where you land before you build.</div>

<div class="row-m"><strong>Compatible ≠ feature parity</strong>Structured output, web search, tool calling — support varies by provider. Always test your target.</div>

---

## Which one should I use?

<div class="cols">

  <div class="box-green">

  **OpenAI SDK**
  - Just getting started
  - OpenAI

  </div>

  <div class="box-red">

  **MS AI Agent SDK**
  - Portability
  - Documention
  - Features

  </div>

</div>

<div class="box-blue">

**Raw HttpClient**
 - Everything is possible, today

</div>

---

<!-- _class: title -->

# link.reka.ai/dotnet

### Code available here

![bottom-right](assets/QRcode_gh-reka-dotnet.jpg)

---

<!-- _class: title -->

![bg left:40%](assets/FrankBoucher.jpeg)

## Thank you

### Frank Boucher

@fboucheros

fboucheros.com

<div style="height: 10px;">&nbsp;</div>

![reka-logo](assets/reka_logo.png)
reka.ai

![bottom-right](assets/confoo-can-we-use-ai-with-net-2026.png)
