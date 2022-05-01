using System.Text.Json.Serialization;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels.Options
{
    public class ImagePollOption : PollOption
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public override PollType Type => PollType.Image;

        [JsonPropertyName("media")]
        public PollMedia Media { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        public ImagePollOption()
        {
        }
    }
}
