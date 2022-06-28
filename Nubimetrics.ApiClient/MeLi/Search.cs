using Nubimetrics.Common.DTOs;

namespace Nubimetrics.ApiClientLibrary
{
    public partial class ApiClient
    {
        public async Task<SearchResults> SearchText(string text)
        {
            Dictionary<string, string> queryParams = new()
            {
                { "q", text }
            };
            var requestUrl = CreateRequestUri($"sites/MLA/search", queryParams);
            return await GetAsync<SearchResults>(requestUrl);
        }
    }
}
