using System.Text.Json.Serialization;

namespace StrawSharp.Models.UserModels
{
    public class UserMeta
    {
        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("monthly_points")]
        public int MonthlyPoints { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        protected bool Equals(UserMeta other)
        {
            return About == other.About && CountryCode == other.CountryCode && MonthlyPoints == other.MonthlyPoints &&
                   TotalPoints == other.TotalPoints && Website == other.Website;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserMeta)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (About != null ? About.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CountryCode != null ? CountryCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MonthlyPoints;
                hashCode = (hashCode * 397) ^ TotalPoints;
                hashCode = (hashCode * 397) ^ (Website != null ? Website.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UserMeta left, UserMeta right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserMeta left, UserMeta right)
        {
            return !Equals(left, right);
        }
    }
}
