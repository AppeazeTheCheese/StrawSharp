using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels.Options
{
    public class DatePollOption : PollOption
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public override OptionType Type => OptionType.Date;

        [JsonPropertyName("date")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime Date { get; set; }

        public DatePollOption()
        {

        }
    }
}
