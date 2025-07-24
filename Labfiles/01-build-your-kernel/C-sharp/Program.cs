﻿using Microsoft.Extensions.Configuration;

// Import namespaces
 using Microsoft.SemanticKernel;

string filePath = Path.GetFullPath("appsettings.json");
var config = new ConfigurationBuilder()
    .AddJsonFile(filePath)
    .Build();

// Set your values in appsettings.json
string apiKey = config["PROJECT_KEY"]!;
string endpoint = config["PROJECT_ENDPOINT"]!;
string deploymentName = config["DEPLOYMENT_NAME"]!;


// Create a kernel with Azure OpenAI chat completion
 var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion(deploymentName, endpoint, apiKey);
 Kernel kernel = builder.Build();

// Test the chat completion service
 var result = await kernel.InvokePromptAsync("Give me a list of 10 breakfast foods with eggs and cheese");
 Console.WriteLine(result);
