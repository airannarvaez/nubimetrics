using Nubimetrics.Common;

namespace Nubimetrics.ETL
{
    public class EtlService : IEtlService
    {
        private int _executionCount;
        private readonly ILogger<EtlService> _logger;
        private readonly ApiClientFactory _apiClient;
        private readonly IConfiguration Configuration;

        public EtlService(ILogger<EtlService> logger, ApiClientFactory apiClient, IConfiguration configuration)
        {
            _logger = logger;
            _apiClient = apiClient;
            Configuration = configuration;
        }

        public async Task ExtractData(int frequency, CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ++_executionCount;

                _logger.LogInformation("{ServiceName} working, execution count: {Count}", nameof(EtlService), _executionCount);

                var api = _apiClient.Instance();

                var currencies = await api.GetCurrencies();

                SaveFile.SaveToCsv(currencies, $"{ Configuration["outputFolder"] }/Test-{DateTime.Now:yyyy-MM-dd HH-mm-ss}.csv");

                await Task.Delay(frequency * 1000, stoppingToken);
            }
        }

    }
}
