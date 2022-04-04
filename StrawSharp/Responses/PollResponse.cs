using System.Text.Json.Serialization;
using StrawSharp.Models;

namespace StrawSharp.Responses
{
    public class PollResponse : BaseResponse
    {
        [JsonPropertyName("poll")]
        public Poll Poll { get; set; }
    }
}
