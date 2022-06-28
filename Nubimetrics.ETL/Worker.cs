namespace Nubimetrics.ETL
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        public IConfiguration Configuration { get; }

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            Configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(Worker)} is running.");

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            if (int.TryParse(Configuration["frecuencyInSeconds"], out int frequency))
            {
                _logger.LogInformation($"{nameof(Worker)} is working.");

                using IServiceScope scope = _serviceProvider.CreateScope();
                IEtlService etlService = scope.ServiceProvider.GetRequiredService<IEtlService>();

                await etlService.ExtractData(frequency, stoppingToken);
            }
            else
            {
                throw new InvalidDataException("frecuencyInSeconds");
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"{nameof(Worker)} is stopping.");
            await base.StopAsync(stoppingToken);
        }
    }
}