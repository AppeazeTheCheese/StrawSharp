using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class PollMeta
    {
        [JsonPropertyName("comment_count")]
        [DefaultValue(0)]
        public int CommentCount { get; set; } = 0;

        [JsonPropertyName("creator_country")]
        [DefaultValue(null)]
        public string CreatorCountry { get; set; }

        [JsonPropertyName("description")]
        [DefaultValue("")]
        public string Description { get; set; } = "";

        [JsonPropertyName("last_vote_at")] 
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [DefaultValue(typeof(DateTime), null)]
        public DateTime? LastVoteAt { get; set; }

        [JsonPropertyName("location")]
        [DefaultValue("")]
        public string Location { get; set; } = "";

        [JsonPropertyName("participant_count")]
        [DefaultValue(0)]
        public int ParticipantCount { get; set; }

        [JsonPropertyName("pin_code_expired_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [DefaultValue(typeof(DateTime), null)]
        public DateTime? PinCodeExpiration { get; set; }

        [JsonPropertyName("timezone")]
        [DefaultValue(null)]
        public string TimeZone { get; set; }

        [JsonPropertyName("view_count")]
        [DefaultValue(0)]
        public int ViewCount { get; set; }

        [JsonPropertyName("vote_count")]
        [DefaultValue(0)]
        public int VoteCount { get; set; }
    }
}