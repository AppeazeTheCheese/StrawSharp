using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models.PollModels
{
    public class PollMeta
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("participant_count")]
        public int? ParticipantCount { get; set; }

        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        [JsonPropertyName("comment_count")]
        public int? CommentCount { get; set; }

        [JsonPropertyName("creator_country")]
        public string CreatorCountry { get; set; }

        [JsonPropertyName("pin_code_expired_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? PinCodeExpiration { get; set; }

        [JsonPropertyName("last_vote_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? LastVoteAt { get; set; }

        [JsonPropertyName("timezone")]
        [JsonConverter(typeof(StringTimeZoneInfoConverter))]
        public TimeZoneInfo TimeZone { get; set; }

        public PollMeta() { }

        public PollMeta(PollMeta other)
        {
            if (other == null) return;
            Description = other.Description;
            Location = other.Location;
            VoteCount = other.VoteCount;
            ParticipantCount = other.ParticipantCount;
            ViewCount = other.ViewCount;
            CommentCount = other.CommentCount;
            CreatorCountry = other.CreatorCountry;
            PinCodeExpiration = other.PinCodeExpiration;
            LastVoteAt = other.LastVoteAt;
            TimeZone = other.TimeZone;
        }

        protected bool Equals(PollMeta other)
        {
            return Description == other.Description && Location == other.Location && VoteCount == other.VoteCount &&
                   ParticipantCount == other.ParticipantCount && ViewCount == other.ViewCount &&
                   CommentCount == other.CommentCount && CreatorCountry == other.CreatorCountry &&
                   Nullable.Equals(PinCodeExpiration, other.PinCodeExpiration) &&
                   Nullable.Equals(LastVoteAt, other.LastVoteAt) && TimeZone == other.TimeZone;
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
                var hashCode = (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Location != null ? Location.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ VoteCount;
                hashCode = (hashCode * 397) ^ ParticipantCount.GetHashCode();
                hashCode = (hashCode * 397) ^ ViewCount;
                hashCode = (hashCode * 397) ^ CommentCount.GetHashCode();
                hashCode = (hashCode * 397) ^ (CreatorCountry != null ? CreatorCountry.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PinCodeExpiration.GetHashCode();
                hashCode = (hashCode * 397) ^ LastVoteAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (TimeZone != null ? TimeZone.GetHashCode() : 0);
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