using Nubimetrics.ETL;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        string baseUrl = hostContext.Configuration["baseUrl"];
        services.AddTransient(p => new ApiClientFactory(new Uri(baseUrl)));
        services.AddSingleton<IEtlService, EtlService>();
    })
    .Build();

await host.RunAsync();
