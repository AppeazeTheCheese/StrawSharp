using System.Text.Json.Serialization;

namespace StrawSharp.Models
{
    public class PollMedia
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; } = null;

        [JsonPropertyName("path")]
        public string Path { get; set; } = null;

        protected bool Equals(PollMedia other)
        {
            return Id == other.Id && Path == other.Path;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollMedia)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (Path != null ? Path.GetHashCode() : 0);
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