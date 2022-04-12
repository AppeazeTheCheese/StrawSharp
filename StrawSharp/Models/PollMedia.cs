using System.ComponentModel;
using System.Text.Json.Serialization;

namespace StrawSharp.Models
{
    public class PollMedia
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)
        public string Id { get; set; } = null;

        [JsonPropertyName("path")]
        public string Path { get; set; } = null;
    }
}