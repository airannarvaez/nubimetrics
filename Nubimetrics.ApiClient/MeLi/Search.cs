using Nubimetrics.Common.DTOs;

namespace Nubimetrics.ApiClientLibrary
{
    public partial class ApiClient
    {
        public async Task<SearchResults> SearchText(string text)
        {
            var requestUrl = CreateRequestUri($"sites/MLA/search", text);
            return await GetAsync<SearchResults>(requestUrl);
        }
    }
}
