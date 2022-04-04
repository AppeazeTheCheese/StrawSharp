using System.ComponentModel;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class PollOption
    {
        [JsonPropertyName("id")]
        [DefaultValue(null)]
        public string Id { get; set; } = null;

        [JsonPropertyName("is_write_in")]
        [JsonConverter(typeof(BoolConverter))]
        [DefaultValue(false)]
        public bool IsWriteIn { get; set; } = false;

        [JsonPropertyName("max_votes")]
        [DefaultValue(0)]
        public int MaxVotes { get; set; } = 0;

        [JsonPropertyName("position")]
        [DefaultValue(0)]
        public int Position { get; set; } = 0;

        [JsonPropertyName("secondary")]
        [DefaultValue(null)]
        public object Secondary { get; set; } = null;

        [JsonPropertyName("value")]
        [DefaultValue("")]
        public string Value { get; set; } = null;

        [JsonPropertyName("vote_count")]
        [DefaultValue(0)]
        public int VoteCount { get; set; } = 0;
    }
}