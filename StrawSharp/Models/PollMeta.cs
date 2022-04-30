using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class PollMeta
    {
        [JsonPropertyName("comment_count")]
        public int? CommentCount { get; set; } = 0;

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
        public int? ParticipantCount { get; set; }

        [JsonPropertyName("pin_code_expired_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? PinCodeExpiration { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        protected bool Equals(PollMeta other)
        {
            return CommentCount == other.CommentCount && CreatorCountry == other.CreatorCountry &&
                   Description == other.Description && Nullable.Equals(LastVoteAt, other.LastVoteAt) &&
                   Location == other.Location && ParticipantCount == other.ParticipantCount &&
                   Nullable.Equals(PinCodeExpiration, other.PinCodeExpiration) && TimeZone == other.TimeZone &&
                   ViewCount == other.ViewCount && VoteCount == other.VoteCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollMeta)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CommentCount.GetHashCode();
                hashCode = (hashCode * 397) ^ (CreatorCountry != null ? CreatorCountry.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LastVoteAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ParticipantCount.GetHashCode();
                hashCode = (hashCode * 397) ^ PinCodeExpiration.GetHashCode();
                hashCode = (hashCode * 397) ^ (TimeZone != null ? TimeZone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ViewCount;
                hashCode = (hashCode * 397) ^ VoteCount;
                return hashCode;
            }
        }

        public static bool operator ==(PollMeta left, PollMeta right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollMeta left, PollMeta right)
        {
            return !Equals(left, right);
        }
    }
}