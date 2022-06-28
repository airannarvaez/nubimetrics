using System.Text.Json.Serialization;

namespace Nubimetrics.Common.DTOs
{
    public class Currency
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("decimal_places")]
        public int DecimalPlaces { get; set; }
        
        [JsonPropertyName("todolar")]
        public dynamic ToDolar { get; set; }
    }

    public class CurrencyConversions
    {
        [JsonPropertyName("ratio")]
        public double Ratio { get; set; }
    }
}
