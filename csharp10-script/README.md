# C# Script demos with Reka API

Reka's API is compatible with OpenAI, making it easy to integrate using a familiar structure. These samples demonstrate different ways to call the Reka API in various scenarios. They are built as .NET file-based apps — programs contained within a single `.cs` file that you can build and run without a corresponding project (`.csproj`) file.

![screen capture](../assets/capture-file-based.png)

Requirement:

- Have .NET 10 installed or Docker or CodeSpace

> [!TIP]
> If you don't have .NET installed, you can use the devContainer with [Docker](https://code.visualstudio.com/docs/devcontainers/tutorial) or [CodeSpace](https://docs.github.com/en/codespaces/quickstart) to create your workspace.

## 1. Get your API key

1) Go to the [Reka Platform dashboard](https://link.reka.ai/free)
2) Open the API Keys section on the left
3) Create a new key and copy it to your environment
4) Rename the file `.env-sample` `.env`, and replace the place holder (*HERE_GOES_YOUR_API_KEY*) by the key you just created.

Voilà! Your are all set!

## Try Reka

There are four example in this repository doing exactly the same thing but using different method to achieve it.

- **[1-try-1-try-reka-openai](./1-try-reka-openai.cs)**: Using the OpenAI SDK
- **[2-try-reka-ms-ext](./2-try-reka-ms-ext.cs)**: Using the Microsoft Extension AI for OpenAI
- **[3-try-reka-http](./3-try-reka-http.cs)**: Using the HttpClient to call Reka API directly
- **[4-try-reka-agent-fwk](./4-try-reka-agent-fwk.cs)**: Using the Microsoft Agent Framework

To try any of them you just need to open a terminal in the folder of the example you want to try and type:

```csharp
dotnet run 1-try-reka-openai.cs
```

or

```csharp
dotnet run 2-try-reka-ms-ext.cs
```

or

```csharp
dotnet run 3-try-reka-http.cs
```

or

```csharp
dotnet run 4-try-reka-agent-fwk.cs
```

After a little while you should see the results from the Reka API.

## Do more

You can change the prompt to get different recommendation or you can change the location to get recommendation for another country or city. You can also modify the code and use more advance feature of Reka's API! You can find all the documentation on [https://docs.reka.ai/](https://docs.reka.ai/). You should join our community on [Discord](https://discord.com/invite/MTRJEBvH).

This code was used in a blog post and video that you can find here

- [Blog post: Using AI with .NET 10 Scripts: What Worked, What Didn’t, and Lessons Learned](https://www.frankysnotes.com/2025/09/using-ai-with-net-10-scripts-what.html)
- [Video](https://www.youtube.com/watch?v=JwFHKQkah30)

  ![Using AI with .NET 10 Scripts: What Worked, What Didn’t, and Lessons Learned](../assets/dotnet-ai-file-based.jpg)
