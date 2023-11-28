var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.Aspire_ApiService>("apiservice");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithReference(apiservice);

builder.Build().Run();
