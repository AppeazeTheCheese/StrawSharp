using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class PollOption
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null;

        [JsonPropertyName("is_write_in")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsWriteIn { get; set; } = false;

        [JsonPropertyName("max_votes")]
        public int MaxVotes { get; set; } = 0;

        [JsonPropertyName("position")]
        public int Position { get; set; } = 0;

        [JsonPropertyName("secondary")]
        public object Secondary { get; set; } = null;

        [JsonPropertyName("value")]
        public string Value { get; set; } = null;

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; } = 0;
    }
}