
namespace Nubimetrics.ETL
{
    public interface IEtlService
    {
        Task ExtractData(int frequency, CancellationToken stoppingToken);
    }
}
