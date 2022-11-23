using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
{
    public class Workspace
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
        
        [JsonPropertyName("member_count")]
        public int MemberCount { get; set; }
        
        [JsonPropertyName("poll_count")]
        public int PollCount { get; set; }
        
        public Workspace() { }

        public Workspace(Workspace other)
        {
            Id = other.Id;
            Name = other.Name;
            CreatedAt = other.CreatedAt;
            UpdatedAt = other.UpdatedAt;
            MemberCount = other.MemberCount;
            PollCount = other.PollCount;
        }
        
        protected bool Equals(Workspace other)
        {
            return Id == other.Id && Name == other.Name && CreatedAt.Equals(other.CreatedAt) &&
                   Nullable.Equals(UpdatedAt, other.UpdatedAt) && MemberCount == other.MemberCount &&
                   PollCount == other.PollCount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Workspace) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ MemberCount;
                hashCode = (hashCode * 397) ^ PollCount;
                return hashCode;
            }
        }

        public static bool operator ==(Workspace left, Workspace right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Workspace left, Workspace right)
        {
            return !Equals(left, right);
        }
    }
}