using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.EnumValues;

namespace StrawSharp.Models.PollModels.Options
{
    public class DatePollOption : PollOption
    {
        [JsonPropertyName("type")]
        public override string Type => OptionType.Date;

        [JsonPropertyName("date")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime Date { get; set; }

        public DatePollOption() { }

        public DatePollOption(DatePollOption other) : base(other)
        {
            if (other == null) return;
            Date = other.Date;
        }

        protected bool Equals(DatePollOption other)
        {
            return base.Equals(other) && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DatePollOption)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Date.GetHashCode();
            }
        }

        public static bool operator ==(DatePollOption left, DatePollOption right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DatePollOption left, DatePollOption right)
        {
            return !Equals(left, right);
        }
    }
}
