using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StrawSharp.Responses
{
    public class ErrorResponse : BaseResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
