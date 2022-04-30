using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using StrawSharp.Models;

namespace StrawSharp.Responses
{
    public class PollListResponse : BaseResponse
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("page")]
        public string Page { get; set; }

        [JsonPropertyName("polls")] 
        public Poll[] Polls { get; set; }

        [JsonPropertyName("total_polls")]
        public int TotalPolls { get; set; }
    }
}
