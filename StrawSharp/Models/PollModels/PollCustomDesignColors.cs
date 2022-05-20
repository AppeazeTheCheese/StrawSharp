using System.Drawing;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models.PollModels
{
    public class PollCustomDesignColors
    {
        [JsonPropertyName("background")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color Background { get; set; } = Color.FromArgb(255, 255, 255);

        [JsonPropertyName("border_table")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color BorderTable { get; set; } = Color.FromArgb(209, 213, 219);

        [JsonPropertyName("border_top")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color BorderTop { get; set; } = Color.FromArgb(251, 191, 36);

        [JsonPropertyName("highlight")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color Highlight { get; set; } = Color.FromArgb(79, 70, 229);

        [JsonPropertyName("option")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color Option { get; set; } = Color.FromArgb(17, 24, 39);

        [JsonPropertyName("option_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color OptionBorder { get; set; } = Color.FromArgb(209, 213, 219);

        [JsonPropertyName("page_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color PageBackground { get; set; } = Color.FromArgb(243, 244, 246);

        [JsonPropertyName("primary_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color PrimaryBackground { get; set; } = Color.FromArgb(79, 70, 229);

        [JsonPropertyName("primary_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color PrimaryBorder { get; set; } = Color.FromArgb(79, 70, 229);

        [JsonPropertyName("primary_text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color PrimaryText { get; set; } = Color.FromArgb(255, 255, 255);

        [JsonPropertyName("secondary_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color SecondaryBackground { get; set; } = Color.FromArgb(255, 255, 255);

        [JsonPropertyName("secondary_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color SecondaryBorder { get; set; } = Color.FromArgb(209, 213, 219);

        [JsonPropertyName("secondary_text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color SecondaryText { get; set; } = Color.FromArgb(17, 24, 39);

        [JsonPropertyName("text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color Text { get; set; } = Color.FromArgb(107, 114, 128);

        [JsonPropertyName("title")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color Title { get; set; } = Color.FromArgb(17, 24, 39);

        public PollCustomDesignColors() { }

        public PollCustomDesignColors(PollCustomDesignColors other)
        {
            if (other == null) return;
            Background = other.Background;
            BorderTable = other.BorderTable;
            BorderTop = other.BorderTop;
            Highlight = other.Highlight;
            Option = other.Option;
            OptionBorder = other.OptionBorder;
            PageBackground = other.PageBackground;
            PrimaryBackground = other.PrimaryBackground;
            PrimaryBorder = other.PrimaryBorder;
            PrimaryText = other.PrimaryText;
            SecondaryBackground = other.SecondaryBackground;
            SecondaryBorder = other.SecondaryBorder;
            SecondaryText = other.SecondaryText;
            Text = other.Text;
            Title = other.Title;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Background.GetHashCode();
                hashCode = (hashCode * 397) ^ BorderTable.GetHashCode();
                hashCode = (hashCode * 397) ^ BorderTop.GetHashCode();
                hashCode = (hashCode * 397) ^ Highlight.GetHashCode();
                hashCode = (hashCode * 397) ^ Option.GetHashCode();
                hashCode = (hashCode * 397) ^ OptionBorder.GetHashCode();
                hashCode = (hashCode * 397) ^ PageBackground.GetHashCode();
                hashCode = (hashCode * 397) ^ PrimaryBackground.GetHashCode();
                hashCode = (hashCode * 397) ^ PrimaryBorder.GetHashCode();
                hashCode = (hashCode * 397) ^ PrimaryText.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondaryBackground.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondaryBorder.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondaryText.GetHashCode();
                hashCode = (hashCode * 397) ^ Text.GetHashCode();
                hashCode = (hashCode * 397) ^ Title.GetHashCode();
                return hashCode;
            }
        }
        protected bool Equals(PollCustomDesignColors other)
        {
            return Background.Equals(other.Background) && BorderTable.Equals(other.BorderTable) &&
                   BorderTop.Equals(other.BorderTop) && Highlight.Equals(other.Highlight) &&
                   Option.Equals(other.Option) && OptionBorder.Equals(other.OptionBorder) &&
                   PageBackground.Equals(other.PageBackground) && PrimaryBackground.Equals(other.PrimaryBackground) &&
                   PrimaryBorder.Equals(other.PrimaryBorder) && PrimaryText.Equals(other.PrimaryText) &&
                   SecondaryBackground.Equals(other.SecondaryBackground) &&
                   SecondaryBorder.Equals(other.SecondaryBorder) && SecondaryText.Equals(other.SecondaryText) &&
                   Text.Equals(other.Text) && Title.Equals(other.Title);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollCustomDesignColors)obj);
        }

        public static bool operator ==(PollCustomDesignColors left, PollCustomDesignColors right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollCustomDesignColors left, PollCustomDesignColors right)
        {
            return !Equals(left, right);
        }
    }
}
