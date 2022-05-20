using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.UserModels
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("displayname")]
        public string DisplayName { get; set; }

        [JsonPropertyName("avatar_path")]
        public string AvatarPath { get; set; }

        [JsonPropertyName("subscription")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserSubscription Subscription { get; set; }

        [JsonPropertyName("user_meta")]
        public UserMeta Meta { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("user_config")]
        public UserConfig Config { get; set; }

        public User() { }

        public User(User other)
        {
            if(other == null) return;
            Id = other.Id;
            Username = other.Username;
            DisplayName = other.DisplayName;
            AvatarPath = other.AvatarPath;
            Subscription = other.Subscription;
            Meta = new UserMeta(other.Meta);
            CreatedAt = other.CreatedAt;
            Config = new UserConfig(other.Config);
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && Username == other.Username && DisplayName == other.DisplayName &&
                   AvatarPath == other.AvatarPath && CreatedAt.Equals(other.CreatedAt) &&
                   Subscription == other.Subscription && Equals(Meta, other.Meta);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DisplayName != null ? DisplayName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AvatarPath != null ? AvatarPath.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Subscription;
                hashCode = (hashCode * 397) ^ (Meta != null ? Meta.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }
    }
}
