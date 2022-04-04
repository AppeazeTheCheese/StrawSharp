using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class Poll
    {
        public Poll(){}

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("creator")]
        [DefaultValue(typeof(User), null)]
        public User Creator { get; set; } = null;

        [JsonPropertyName("id")]
        [DefaultValue(null)]
        public string Id { get; set; }

        [JsonPropertyName("is_results_visible")]
        [DefaultValue(true)]
        public bool ResultsAreVisible { get; set; }

        [JsonPropertyName("is_votable")]
        [DefaultValue(true)]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsVotable { get; set; }

        [JsonPropertyName("media")]
        [DefaultValue(typeof(PollMedia),null)]
        public PollMedia Media { get; set; }

        [JsonPropertyName("path")]
        [DefaultValue(null)]
        public string Path { get; set; }

        [JsonPropertyName("pin_code")]
        [DefaultValue(null)]
        public object PinCode { get; set; }

        [JsonPropertyName("poll_config")]
        [DefaultValue(typeof(PollConfig), null)]
        public PollConfig Config { get; set; } = new PollConfig();

        [JsonPropertyName("poll_meta")]
        [DefaultValue(typeof(PollMeta), null)]
        public PollMeta Meta { get; set; } = new PollMeta();

        [JsonPropertyName("poll_options")]
        public List<PollOption> Options { get; set; } = new List<PollOption>();

        [JsonPropertyName("reset_at")]
        [DefaultValue(typeof(DateTime), null)]
        public DateTime? ResetAt { get; set; }

        [JsonPropertyName("results_key")]
        [DefaultValue(null)]
        public string ResultsKey { get; set; }

        [JsonPropertyName("results_path")]
        [DefaultValue(null)]
        public string ResultsPath { get; set; }

        [JsonPropertyName("slug")]
        [DefaultValue(null)]
        public string Slug { get; set; }

        [JsonPropertyName("status")]
        [DefaultValue(null)]
        public string Status { get; set; }

        [JsonPropertyName("title")]
        [DefaultValue("")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        [DefaultValue("")]
        public string Type { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [DefaultValue(typeof(DateTime), null)]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("url")]
        [DefaultValue("")]
        public string Url { get; set; }

        [JsonPropertyName("version")]
        [DefaultValue("")]
        public string Version { get; set; }
    }
}
