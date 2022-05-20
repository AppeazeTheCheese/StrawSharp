using System.Text.Json.Serialization;

namespace StrawSharp.Models.ResponseModels
{
    public class ErrorResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        public ErrorResponse() { }
    }
}
