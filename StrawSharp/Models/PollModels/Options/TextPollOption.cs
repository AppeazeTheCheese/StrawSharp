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

        public TextPollOption()
        {
        }
    }
}
