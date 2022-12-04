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
        
        [JsonPropertyName("custom_text_input_field")]
        public string InputFieldText { get; set; }

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

        public PollTheme() { }

        public PollTheme(PollTheme other)
        {
            Id = other.Id;
            Name = other.Name;
            PageAppearance = other.PageAppearance;
            PageLayout = other.PageLayout;
            TitleColor = other.TitleColor;
            TextColor = other.TextColor;
            BorderColor = other.BorderColor;
            BoxBackgroundColor = other.BoxBackgroundColor;
            BoxBorderColor = other.BoxBorderColor;
            InputBackgroundColor = other.InputBackgroundColor;
            InputBorderColor = other.InputBorderColor;
            InputHighlightColor = other.InputHighlightColor;
            InputTextColor = other.InputTextColor;
            PageBackgroundColor = other.PageBackgroundColor;
            PrimaryButtonBackgroundColor = other.PrimaryButtonBackgroundColor;
            PrimaryButtonBorderColor = other.PrimaryButtonBorderColor;
            PrimaryButtonTextColor = other.PrimaryButtonTextColor;
            SecondaryButtonBackgroundColor = other.SecondaryButtonBackgroundColor;
            SecondaryButtonBorderColor = other.SecondaryButtonBorderColor;
            SecondaryButtonTextColor = other.SecondaryButtonTextColor;
            OptionColors = new List<Color>(other.OptionColors);
            BackToPollText = other.BackToPollText;
            InstructionsText = other.InstructionsText;
            LiveResultsText = other.LiveResultsText;
            ParticipantsText = other.ParticipantsText;
            RefreshResultsText = other.RefreshResultsText;
            ResultsText = other.ResultsText;
            ShareText = other.ShareText;
            TotalVotesText = other.TotalVotesText;
            UpdateVoteText = other.UpdateVoteText;
            VoteText = other.VoteText;
            VotesText = other.VotesText;
            InputFieldText = other.InputFieldText;
            Font = other.Font;
            BoxShadow = other.BoxShadow;
            HideShareButton = other.HideShareButton;
            UseCustomText = other.UseCustomText;
            CreatedAt = other.CreatedAt;
            UpdatedAt = other.UpdatedAt;
        }

        protected bool Equals(PollTheme other)
        {
            return Id == other.Id && Name == other.Name && PageAppearance == other.PageAppearance &&
                   PageLayout == other.PageLayout && Nullable.Equals(TitleColor, other.TitleColor) &&
                   Nullable.Equals(TextColor, other.TextColor) && Nullable.Equals(BorderColor, other.BorderColor) &&
                   Nullable.Equals(BoxBackgroundColor, other.BoxBackgroundColor) &&
                   Nullable.Equals(BoxBorderColor, other.BoxBorderColor) &&
                   Nullable.Equals(BoxBorderTopColor, other.BoxBorderTopColor) &&
                   Nullable.Equals(InputBackgroundColor, other.InputBackgroundColor) &&
                   Nullable.Equals(InputBorderColor, other.InputBorderColor) &&
                   Nullable.Equals(InputHighlightColor, other.InputHighlightColor) &&
                   Nullable.Equals(InputTextColor, other.InputTextColor) &&
                   Nullable.Equals(PageBackgroundColor, other.PageBackgroundColor) &&
                   Nullable.Equals(PrimaryButtonBackgroundColor, other.PrimaryButtonBackgroundColor) &&
                   Nullable.Equals(PrimaryButtonBorderColor, other.PrimaryButtonBorderColor) &&
                   Nullable.Equals(PrimaryButtonTextColor, other.PrimaryButtonTextColor) &&
                   Nullable.Equals(SecondaryButtonBackgroundColor, other.SecondaryButtonBackgroundColor) &&
                   Nullable.Equals(SecondaryButtonBorderColor, other.SecondaryButtonBorderColor) &&
                   Nullable.Equals(SecondaryButtonTextColor, other.SecondaryButtonTextColor) &&
                   Equals(OptionColors, other.OptionColors) && BackToPollText == other.BackToPollText &&
                   InstructionsText == other.InstructionsText && LiveResultsText == other.LiveResultsText &&
                   ParticipantsText == other.ParticipantsText && RefreshResultsText == other.RefreshResultsText &&
                   ResultsText == other.ResultsText && ShareText == other.ShareText &&
                   TotalVotesText == other.TotalVotesText && UpdateVoteText == other.UpdateVoteText &&
                   VoteText == other.VoteText && VotesText == other.VotesText &&
                   InputFieldText == other.InputFieldText && Font == other.Font && BoxShadow == other.BoxShadow &&
                   HideShareButton == other.HideShareButton && UseCustomText == other.UseCustomText &&
                   CreatedAt.Equals(other.CreatedAt) && Nullable.Equals(UpdatedAt, other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollTheme) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PageAppearance != null ? PageAppearance.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PageLayout != null ? PageLayout.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ TitleColor.GetHashCode();
                hashCode = (hashCode * 397) ^ TextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BoxBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BoxBorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ BoxBorderTopColor.GetHashCode();
                hashCode = (hashCode * 397) ^ InputBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ InputBorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ InputHighlightColor.GetHashCode();
                hashCode = (hashCode * 397) ^ InputTextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ PageBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ PrimaryButtonBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ PrimaryButtonBorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ PrimaryButtonTextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondaryButtonBackgroundColor.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondaryButtonBorderColor.GetHashCode();
                hashCode = (hashCode * 397) ^ SecondaryButtonTextColor.GetHashCode();
                hashCode = (hashCode * 397) ^ (OptionColors != null ? OptionColors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BackToPollText != null ? BackToPollText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InstructionsText != null ? InstructionsText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LiveResultsText != null ? LiveResultsText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ParticipantsText != null ? ParticipantsText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RefreshResultsText != null ? RefreshResultsText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ResultsText != null ? ResultsText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShareText != null ? ShareText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalVotesText != null ? TotalVotesText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UpdateVoteText != null ? UpdateVoteText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VoteText != null ? VoteText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VotesText != null ? VotesText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InputFieldText != null ? InputFieldText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Font != null ? Font.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BoxShadow.GetHashCode();
                hashCode = (hashCode * 397) ^ HideShareButton.GetHashCode();
                hashCode = (hashCode * 397) ^ UseCustomText.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(PollTheme left, PollTheme right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollTheme left, PollTheme right)
        {
            return !Equals(left, right);
        }
    }
}