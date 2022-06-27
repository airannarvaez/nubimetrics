using System.Text.Json.Serialization;

namespace Nubimetrics.Common.DTOs
{
    public class SearchResults
    {
        [JsonPropertyName("site_id")]
        public string SiteId { get; set; }

        [JsonPropertyName("country_default_time_zone")]
        public string CountryDefaultTimeZone { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("paging")]
        public dynamic Paging { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        [JsonPropertyName("sort")]
        public dynamic Sort { get; set; }

        [JsonPropertyName("available_sorts")]
        public List<dynamic> AvailableSorts { get; set; }

        [JsonPropertyName("filters")]
        public List<dynamic> Filters { get; set; }

        [JsonPropertyName("available_filters")]
        public List<dynamic> AvailableFilters { get; set; }
    }
}
