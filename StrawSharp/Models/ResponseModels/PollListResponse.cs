using System.Text.Json.Serialization;
using StrawSharp.Models.PollModels;

namespace StrawSharp.Models.ResponseModels
{
    public class PollListResponse
    {
        [JsonPropertyName("data")]
        public Poll[] Data { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        public PollListResponse() { }
    }
}
