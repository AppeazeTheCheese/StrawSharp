using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels.Options
{
    public class TimeRangePollOption : PollOption
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public override OptionType Type => OptionType.TimeRange;

        [JsonPropertyName("start_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("end_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EndTime { get; set; }

        public TimeRangePollOption()
        {
        }
    }
}
