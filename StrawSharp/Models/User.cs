using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models
{
    public class User
    {
        [JsonPropertyName("avatar_path")]
        public string AvatarPath { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("displayname")]
        public string DisplayName { get; set; }

        [JsonPropertyName("status")]
        public UserStatus Status { get; set; }

        [JsonPropertyName("subscription")]
        public UserSubscription Subscription { get; set; }

        [JsonPropertyName("monthly_points")]
        public int MonthlyPoints { get; set; }

        [JsonPropertyName("user_meta")]
        public UserMeta Meta { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
