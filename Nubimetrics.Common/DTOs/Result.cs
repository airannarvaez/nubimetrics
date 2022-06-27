
using System.Text.Json.Serialization;

namespace Nubimetrics.Common.DTOs
{
    public class Result
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("site_id")]
        public string SiteId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("seller")]
        public Seller Seller { get; set; }

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; }
    }

    public class Seller
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
