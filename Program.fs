module IsolateFunctions.Program
open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting;

let host = 
    HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .Build();

host.Run();
