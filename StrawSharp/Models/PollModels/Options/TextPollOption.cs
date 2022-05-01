using System.Text.Json.Serialization;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels.Options
{
    public class TextPollOption : PollOption
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public override PollType Type => PollType.Text;

        [JsonPropertyName("value")]
        public string Value { get; set; }

        public TextPollOption()
        {
        }
    }
}
