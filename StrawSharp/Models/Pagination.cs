using System.Text.Json.Serialization;

namespace StrawSharp.Models
{
    public class Pagination
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }
    }
}
