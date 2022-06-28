using Nubimetrics.Common.DTOs;

namespace Nubimetrics.ApiClientLibrary
{
    public partial class ApiClient
    {
        public async Task<List<Currency>> GetCurrencies()
        {
            var requestUrl = CreateRequestUri("currencies");
            var currencies = await GetAsync<List<Currency>>(requestUrl);

            foreach (var currency in currencies)
            {
                try
                {
                    var conversion = await GetConversion(currency.Id);
                    currency.ToDolar = conversion.Ratio;
                }
                catch
                {
                    currency.ToDolar = "not allowed";
                }
            }
            return currencies;
        }

        public async Task<CurrencyConversions> GetConversion(string currencyCode)
        {
            Dictionary<string, string> queryParams = new()
            {
                { "from", currencyCode }, { "to", "USD" }
            };
            var requestUrl = CreateRequestUri($"currency_conversions/search", queryParams);
            return await GetAsync<CurrencyConversions>(requestUrl);
        }
    }
}
