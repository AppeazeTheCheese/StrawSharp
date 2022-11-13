using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.UserModels;

namespace StrawSharp.Models.PollModels
{
    public class PollMedia
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of media. Known values in <see cref="EnumValues.MediaType"/>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        public PollMedia() { }

        public PollMedia(PollMedia other)
        {
            if (other == null) return;
            Id = other.Id;
            Type = other.Type;
            User = new User(other.User);
            Source = other.Source;
            Url = other.Url;
            Width = other.Width;
            Height = other.Height;
            CreatedAt = other.CreatedAt;
            UpdatedAt = other.UpdatedAt;
        }

        protected bool Equals(PollMedia other)
        {
            return Id == other.Id && Type == other.Type && Equals(User, other.User) && Source == other.Source &&
                   Url == other.Url && Width == other.Width && Height == other.Height &&
                   CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollMedia) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Source != null ? Source.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Width;
                hashCode = (hashCode * 397) ^ Height;
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(PollMedia left, PollMedia right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollMedia left, PollMedia right)
        {
            return !Equals(left, right);
        }
    }
}