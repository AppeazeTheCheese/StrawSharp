using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.EnumValues;

namespace StrawSharp.Models.PollModels.Options
{
    public class TimeRangePollOption : PollOption
    {
        [JsonPropertyName("type")]
        public override string Type => OptionType.TimeRange;

        [JsonPropertyName("start_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("end_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EndTime { get; set; }

        public TimeRangePollOption() { }

        public TimeRangePollOption(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public TimeRangePollOption(TimeRangePollOption other) : base(other)
        {
            if (other == null) return;
            StartTime = other.StartTime;
            EndTime = other.EndTime;
        }

        protected bool Equals(TimeRangePollOption other)
        {
            return base.Equals(other) && StartTime.Equals(other.StartTime) && EndTime.Equals(other.EndTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TimeRangePollOption)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ StartTime.GetHashCode();
                hashCode = (hashCode * 397) ^ EndTime.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(TimeRangePollOption left, TimeRangePollOption right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TimeRangePollOption left, TimeRangePollOption right)
        {
            return !Equals(left, right);
        }
    }
}
