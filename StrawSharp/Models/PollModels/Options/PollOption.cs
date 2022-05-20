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

        public PollOption() { }

        public PollOption(PollOption other)
        {
            if (other == null) return;
            Id = other.Id;
            Description = other.Description;
            IsWriteIn = other.IsWriteIn;
            MaxVotes = other.MaxVotes;
            Position = other.Position;
            VoteCount = other.VoteCount;
        }

        protected bool Equals(PollOption other)
        {
            return Id == other.Id && Type == other.Type && Description == other.Description &&
                   IsWriteIn == other.IsWriteIn && MaxVotes == other.MaxVotes && Position == other.Position &&
                   VoteCount == other.VoteCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollOption)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Type;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsWriteIn.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxVotes;
                hashCode = (hashCode * 397) ^ Position;
                hashCode = (hashCode * 397) ^ VoteCount;
                return hashCode;
            }
        }

        public static bool operator ==(PollOption left, PollOption right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollOption left, PollOption right)
        {
            return !Equals(left, right);
        }
    }
}