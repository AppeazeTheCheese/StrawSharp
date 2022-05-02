using System.Text.Json.Serialization;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels.Options
{
    public class PollOption
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null;

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public virtual OptionType Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("is_write_in")]
        public bool IsWriteIn { get; set; } = false;

        [JsonPropertyName("max_votes")]
        public int MaxVotes { get; set; } = 0;

        [JsonPropertyName("position")]
        public int Position { get; set; } = 0;

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; } = 0;
    }
}