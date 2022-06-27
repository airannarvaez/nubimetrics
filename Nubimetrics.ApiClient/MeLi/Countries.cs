using Nubimetrics.Common;

namespace Nubimetrics.ApiClientLibrary
{
    public partial class ApiClient
    {

        public async Task<Country> GetCountry(string country)
        {
            var requestUrl = CreateRequestUri($"classified_locations/countries/{ country }");
            return await GetAsync<Country>(requestUrl);
        }
    }
}
