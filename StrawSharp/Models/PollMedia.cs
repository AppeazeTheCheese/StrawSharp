using System.ComponentModel;
using System.Text.Json.Serialization;

namespace StrawSharp.Models
{
    public class PollMedia
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DefaultValue(null)]
        public string Id { get; set; } = null;

        [JsonPropertyName("path")]
        [DefaultValue(null)]
        public string Path { get; set; } = null;
    }
}