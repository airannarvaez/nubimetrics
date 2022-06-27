using System.Text.Json.Serialization;

namespace Nubimetrics.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CountryCode
    {
        AR,
        BR,
        CO
    }
}
