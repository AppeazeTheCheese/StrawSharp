using System.Text.Json.Serialization;

namespace StrawSharp.Models
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
    }
}
