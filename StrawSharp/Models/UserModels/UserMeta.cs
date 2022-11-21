using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models.UserModels
{
    public class UserMeta
    {
        [JsonPropertyName("about")] public string About { get; set; }

        [JsonPropertyName("allow_active_vanity_url")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowVanityUrl { get; set; }

        [JsonPropertyName("allow_clickable_links")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowClickableLinks { get; set; }

        [JsonPropertyName("allow_custom_poll_links")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowCustomPollLinks { get; set; }

        [JsonPropertyName("allow_custom_themes")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowCustomThemes { get; set; }

        [JsonPropertyName("allow_image_upload")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowImageUpload { get; set; }

        [JsonPropertyName("allow_priority_support")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowPrioritySupport { get; set; }

        [JsonPropertyName("allow_remove_ads")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowRemoveAds { get; set; }
        
        [JsonPropertyName("allow_remove_branding")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowRemoveBranding { get; set; }
        
        [JsonPropertyName("allow_theme_logo")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool AllowThemeLogo { get; set; }
        
        [JsonPropertyName("workspace_members_quota")]
        public int WorkspaceMembersQuota { get; set; }
        
        [JsonPropertyName("workspace_members_used")]
        public int WorkspaceMembersUsed { get; set; }
        
        [JsonPropertyName("workspaces_quota")]
        public int WorkspacesQuota { get; set; }
        
        [JsonPropertyName("workspaces_used")]
        public int WorkspacesUsed { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("monthly_points")]
        public int MonthlyPoints { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }

        public UserMeta()
        {
        }

        public UserMeta(UserMeta other)
        {
            if (other == null) return;
            About = other.About;
            Website = other.Website;
            CountryCode = other.CountryCode;
            MonthlyPoints = other.MonthlyPoints;
            TotalPoints = other.TotalPoints;
        }

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
            return Equals((UserMeta) obj);
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