using System.Text.Json.Serialization;
using StrawSharp.Models;

namespace StrawSharp.Responses
{
    internal class MediaResponse : BaseResponse
    {
        [JsonPropertyName("media")]
        public PollMedia Media { get; set; }
    }
}
