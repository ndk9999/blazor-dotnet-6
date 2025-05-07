var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireProduct_ApiService>("apiservice");

builder.AddProject<Projects.AspireProduct_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
