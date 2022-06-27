using System.Text.Json.Serialization;

namespace Nubimetrics.Common.DTOs
{
    public class GeoInformation
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

    }
}
