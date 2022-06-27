using System.Text.Json.Serialization;

namespace Nubimetrics.Common.DTOs
{
    public class State
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
