using Nubimetrics.Common;
using System.Text.Json;

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

        /// <summary>
        /// Common method for making POST calls
        /// </summary>
        private async Task<T> PostAsync<T>(Uri requestUrl, T content)
        {
            throw new NotImplementedException();
        }

        private async Task<T1> PostAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Common method for making PUT calls
        /// </summary>
        private async Task<T> PutAsync<T>(Uri requestUrl, T content)
        {
            throw new NotImplementedException();
        }

        private async Task<T1> PutAsync<T1, T2>(Uri requestUrl, T2 content)
        {
            throw new NotImplementedException();
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = !string.IsNullOrEmpty(queryString) ? queryString : uriBuilder.Query;

            return uriBuilder.Uri;
        }

    }

}