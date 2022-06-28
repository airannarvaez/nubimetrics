using System.Text.Json;
using System.Web;

namespace Nubimetrics.ApiClientLibrary
{
    public partial class ApiClient
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndpoint { get; set; }

        public string ApiEndpoint
        {
            get
            {
                return BaseEndpoint.ToString();
            }
        }

        public ApiClient(Uri baseEndpoint)
        {
            BaseEndpoint = baseEndpoint ?? throw new ArgumentNullException("baseEndpoint");
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Common method for making GET calls
        /// </summary>
        private async Task<T> GetAsync<T>(Uri requestUrl)
        {
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            try
            {
                return JsonSerializer.Deserialize<T>(data);
            }
            catch
            {
                return (T)Convert.ChangeType(data, typeof(T));
            }
        }

        private Uri CreateRequestUri(string relativePath, Dictionary<string, string>? queryParams = null)
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);

            if (queryParams != null)
            {
                var httpValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);

                foreach (KeyValuePair<string, string> queryParam in queryParams)
                {
                    httpValueCollection.Add(queryParam.Key, queryParam.Value);
                }

                uriBuilder.Query = httpValueCollection.ToString();
            }
            return uriBuilder.Uri;
        }

    }

}