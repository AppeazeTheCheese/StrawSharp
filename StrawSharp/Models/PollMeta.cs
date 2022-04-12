using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class PollMeta
    {
        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; } = 0;

        [JsonPropertyName("creator_country")]
        public string CreatorCountry { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("last_vote_at")] 
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? LastVoteAt { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; } = "";

        [JsonPropertyName("participant_count")]
        public int ParticipantCount { get; set; }

        [JsonPropertyName("pin_code_expired_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? PinCodeExpiration { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}