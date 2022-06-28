using Nubimetrics.ApiClientLibrary;

namespace Nubimetrics.ETL
{
    public class ApiClientFactory
    {
        private readonly ApiClient restClient;

        public ApiClientFactory(Uri baseUrl)
        {
            this.restClient = new ApiClient(baseUrl);
        }

        public ApiClient Instance()
        {
            return restClient;
        }
    }
}
