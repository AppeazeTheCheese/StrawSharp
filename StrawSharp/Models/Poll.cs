using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models
{
    public class Poll
    {
        public Poll(){}

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("creator")]
        public User Creator { get; set; } = null;

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("is_results_visible")]
        public bool ResultsAreVisible { get; set; }

        [JsonPropertyName("is_votable")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsVotable { get; set; }

        [JsonPropertyName("media")]
        public PollMedia Media { get; set; } = new PollMedia();

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("pin_code")]
        public int? PinCode { get; set; }

        [JsonPropertyName("poll_config")]
        public PollConfig Config { get; set; } = new PollConfig();

        [JsonPropertyName("poll_meta")]
        public PollMeta Meta { get; set; } = new PollMeta();

        [JsonPropertyName("poll_options")]
        public List<PollOption> Options { get; set; } = new List<PollOption>();

        [JsonPropertyName("reset_at")]
        public DateTime? ResetAt { get; set; }

        [JsonPropertyName("results_key")]
        public string ResultsKey { get; set; }

        [JsonPropertyName("results_path")]
        public string ResultsPath { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("status")] 
        public PollStatus Status { get; set; } = PollStatus.Published;

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
