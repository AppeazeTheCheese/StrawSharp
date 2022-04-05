using System.Text.Json.Serialization;

namespace StrawSharp.Responses
{
    public class MessageResponse : BaseResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
