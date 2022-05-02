﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;
using StrawSharp.Models.PollModels.Options;
using StrawSharp.Models.UserModels;

namespace StrawSharp.Models.PollModels
{
    public class Poll
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; } = null;

        [JsonPropertyName("media")]
        public PollMedia Media { get; set; } = new PollMedia();

        [JsonPropertyName("poll_options")]
        [JsonConverter(typeof(PollOptionConverter))]
        public List<PollOption> Options { get; set; } = new List<PollOption>();

        [JsonPropertyName("poll_config")]
        public PollConfig Config { get; set; } = new PollConfig();

        [JsonPropertyName("poll_meta")]
        public PollMeta Meta { get; set; } = new PollMeta();

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public PollType Type { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("reset_at")]
        public DateTime? ResetAt { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("pin_code")]
        public int? PinCode { get; set; }

        [JsonPropertyName("results_path")]
        public string ResultsPath { get; set; }

        [JsonPropertyName("status")] 
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public PollStatus Status { get; set; } = PollStatus.Published;

        [JsonPropertyName("url")]
        public string Url { get; set; }

        protected bool Equals(Poll other)
        {
            return Id == other.Id && Title == other.Title && Equals(User, other.User) && Equals(Media, other.Media) &&
                   Equals(Options, other.Options) && Equals(Config, other.Config) && Equals(Meta, other.Meta) &&
                   Type == other.Type && Version == other.Version && CreatedAt.Equals(other.CreatedAt) &&
                   Nullable.Equals(UpdatedAt, other.UpdatedAt) && Nullable.Equals(ResetAt, other.ResetAt) &&
                   Path == other.Path && Slug == other.Slug && PinCode == other.PinCode &&
                   ResultsPath == other.ResultsPath && Status == other.Status && Url == other.Url;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Poll)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Media != null ? Media.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Options != null ? Options.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Config != null ? Config.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Meta != null ? Meta.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Type;
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ ResetAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Slug != null ? Slug.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PinCode.GetHashCode();
                hashCode = (hashCode * 397) ^ (ResultsPath != null ? ResultsPath.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Status;
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Poll left, Poll right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Poll left, Poll right)
        {
            return !Equals(left, right);
        }
    }
}