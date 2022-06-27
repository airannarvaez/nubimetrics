
using System.Text.Json.Serialization;

namespace Nubimetrics.Common
{
    public class State
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
