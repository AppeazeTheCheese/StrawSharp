using System;
using System.Drawing;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models.PollModels
{
    public class PollThemeColor
    {
        [JsonPropertyName("title")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? TitleColor { get; set; }

        [JsonPropertyName("text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? TextColor { get; set; }

        [JsonPropertyName("border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? BorderColor { get; set; }

        [JsonPropertyName("box_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? BoxBackgroundColor { get; set; }

        [JsonPropertyName("box_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? BoxBorderColor { get; set; }

        [JsonPropertyName("box_border_top")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? BoxBorderTopColor { get; set; }

        [JsonPropertyName("page_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? PageBackgroundColor { get; set; }

        [JsonPropertyName("button_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? ButtonBackgroundColor { get; set; }

        [JsonPropertyName("button_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? ButtonBorderColor { get; set; }

        [JsonPropertyName("button_text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? ButtonTextColor { get; set; }

        [JsonPropertyName("highlight")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? HighlightColor { get; set; }

        public PollThemeColor() { }

        public PollThemeColor(PollThemeColor other)
        {
            if (other == null) return;

            TitleColor = other.TitleColor;
            TextColor = other.TextColor;
            BorderColor = other.BorderColor;
            BoxBackgroundColor = other.BoxBackgroundColor;
            BoxBorderColor = other.BoxBorderColor;
            BoxBorderTopColor = other.BoxBorderTopColor;
            PageBackgroundColor = other.PageBackgroundColor;
            ButtonBackgroundColor = other.ButtonBackgroundColor;
            ButtonBorderColor = other.ButtonBorderColor;
            ButtonTextColor = other.ButtonTextColor;
            HighlightColor = other.HighlightColor;
        }

        protected bool Equals(PollThemeColor other)
        {
            return Nullable.Equals(TitleColor, other.TitleColor) && Nullable.Equals(TextColor, other.TextColor) &&
                   Nullable.Equals(BorderColor, other.BorderColor) &&
                   Nullable.Equals(BoxBackgroundColor, other.BoxBackgroundColor) &&
                   Nullable.Equals(BoxBorderColor, other.BoxBorderColor) &&
                   Nullable.Equals(BoxBorderTopColor, other.BoxBorderTopColor) &&
                   Nullable.Equals(PageBackgroundColor, other.PageBackgroundColor) &&
                   Nullable.Equals(ButtonBackgroundColor, other.ButtonBackgroundColor) &&
                   Nullable.Equals(ButtonBorderColor, other.ButtonBorderColor) &&
                   Nullable.Equals(ButtonTextColor, other.ButtonTextColor) &&
                   Nullable.Equals(HighlightColor, other.HighlightColor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollThemeColor)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TitleColor.GetHashCode();
                hashCode = (hashCode * 397) ^ TextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BoxBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BoxBorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BoxBorderTopColor.GetHashCode();
                hashCode = (hashCode * 397) ^ PageBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ ButtonBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ ButtonBorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ ButtonTextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ HighlightColor.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(PollThemeColor left, PollThemeColor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollThemeColor left, PollThemeColor right)
        {
            return !Equals(left, right);
        }
    }
}
