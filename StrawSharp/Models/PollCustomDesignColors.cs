using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models
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
    }
}
