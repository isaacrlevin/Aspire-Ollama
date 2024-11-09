var builder = DistributedApplication.CreateBuilder(args);


var ollama = builder.AddOllama("ollama")
                    .AddModel("llama3")
                    .WithDataVolume()
                    .WithContainerRuntimeArgs("--gpus=all")
                    .WithOpenWebUI();

builder.AddProject<Projects.Aspire_Ollama_Web>("webfrontend")
    .WithReference(ollama)
    .WithExternalHttpEndpoints();

builder.Build().Run();
