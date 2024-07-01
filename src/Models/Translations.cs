using System.Text.Json.Serialization;

namespace NumberToTextConverter.Models
{
    class Translations
    {
        [JsonPropertyName("pt")]
        public Dictionary<string, string>? Pt { get; set; }
        [JsonPropertyName("en")]
        public Dictionary<string, string>? En { get; set; }
    }
}