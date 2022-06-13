using System.Text.Json.Serialization;
using StrawSharp.Models.EnumValues;

namespace StrawSharp.Models.PollModels.Options
{
    public class ImagePollOption : PollOption
    {
        [JsonPropertyName("type")]
        public override string Type => OptionType.Image;

        [JsonPropertyName("media")]
        public PollMedia Media { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        public ImagePollOption() { }

        public ImagePollOption(string pollMediaId, string altText)
        {
            Media = new PollMedia {Id = pollMediaId};
            Value = altText;
        }

        public ImagePollOption(ImagePollOption other) : base(other)
        {
            if (other == null) return;
            Media = new PollMedia(other.Media);
            Value = other.Value;
        }

        protected bool Equals(ImagePollOption other)
        {
            return base.Equals(other) && Equals(Media, other.Media) && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ImagePollOption)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Media != null ? Media.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ImagePollOption left, ImagePollOption right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ImagePollOption left, ImagePollOption right)
        {
            return !Equals(left, right);
        }
    }
}
