using System.Text.Json.Serialization;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels.Options
{
    public class TextPollOption : PollOption
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public override OptionType Type => OptionType.Text;

        [JsonPropertyName("value")]
        public string Value { get; set; }

        public TextPollOption() { }

        public TextPollOption(TextPollOption other) : base(other)
        {
            if (other == null) return;
            Value = other.Value;
        }

        protected bool Equals(TextPollOption other)
        {
            return base.Equals(other) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TextPollOption)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }

        public static bool operator ==(TextPollOption left, TextPollOption right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TextPollOption left, TextPollOption right)
        {
            return !Equals(left, right);
        }
    }
}
