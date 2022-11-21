using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.EnumValues;

namespace StrawSharp.Models.PollModels
{
    public class PollTheme
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Known values in <see cref="PollPageAppearance"/>
        /// </summary>
        [JsonPropertyName("page_appearance")]
        public string PageAppearance { get; set; }
        
        /// <summary>
        /// Known values in <see cref="PollPageLayout"/>
        /// </summary>
        [JsonPropertyName("page_layout")]
        public string PageLayout { get; set; }

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
        
        [JsonPropertyName("input_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? InputBackgroundColor { get; set; }
        
        [JsonPropertyName("input_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? InputBorderColor { get; set; }
        
        [JsonPropertyName("input_highlight")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? InputHighlightColor { get; set; }
        
        [JsonPropertyName("input_text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? InputTextColor { get; set; }
        
        [JsonPropertyName("page_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? PageBackgroundColor { get; set; }
        
        [JsonPropertyName("primary_button_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? PrimaryButtonBackgroundColor { get; set; }
        
        [JsonPropertyName("primary_button_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? PrimaryButtonBorderColor { get; set; }
        
        [JsonPropertyName("primary_button_text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? PrimaryButtonTextColor { get; set; }
        
        [JsonPropertyName("secondary_button_bg")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? SecondaryButtonBackgroundColor { get; set; }
        
        [JsonPropertyName("secondary_button_border")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? SecondaryButtonBorderColor { get; set; }
        
        [JsonPropertyName("secondary_button_text")]
        [JsonConverter(typeof(StringColorConverter))]
        public Color? SecondaryButtonTextColor { get; set; }

        [JsonPropertyName("option_colors")]
        [JsonConverter(typeof(StringArrayColorListConverter))]
        public List<Color> OptionColors { get; set; }
        
        [JsonPropertyName("custom_text_back_to_poll")]
        public string BackToPollText { get; set; }
        
        [JsonPropertyName("custom_text_instructions")]
        public string InstructionsText { get; set; }
        
        [JsonPropertyName("custom_text_live_results")]
        public string LiveResultsText { get; set; }
        
        [JsonPropertyName("custom_text_participants")]
        public string ParticipantsText { get; set; }
        
        [JsonPropertyName("custom_text_refresh_results")]
        public string RefreshResultsText { get; set; }
        
        [JsonPropertyName("custom_text_results")]
        public string ResultsText { get; set; }
        
        [JsonPropertyName("custom_text_share")]
        public string ShareText { get; set; }
        
        [JsonPropertyName("custom_text_total_votes")]
        public string TotalVotesText { get; set; }
        
        [JsonPropertyName("custom_text_update_vote")]
        public string UpdateVoteText { get; set; }
        
        [JsonPropertyName("custom_text_vote")]
        public string VoteText { get; set; }
        
        [JsonPropertyName("custom_text_votes")]
        public string VotesText { get; set; }
        
        [JsonPropertyName("font")]
        public string Font { get; set; }
        
        [JsonPropertyName("box_shadow")]
        [JsonConverter(typeof(BitBoolConverter))]
        public bool BoxShadow { get; set; }

        [JsonPropertyName("hide_share_button")]
        public bool HideShareButton { get; set; }
        
        [JsonPropertyName("use_custom_text")]
        public bool UseCustomText { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }
        
        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
    }
}