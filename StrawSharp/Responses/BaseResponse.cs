using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Responses
{
    public class BaseResponse
    {
        [JsonPropertyName("success")]
        [JsonConverter(typeof(BoolConverter))]
        public bool Success { get; set; }
    }
}
