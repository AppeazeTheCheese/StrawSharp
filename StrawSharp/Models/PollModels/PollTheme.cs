using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models.PollModels
{
    public class PollTheme
    {
        [JsonPropertyName("id")] 
        public string Id { get; set; }

        [JsonPropertyName("name")] 
        public string Name { get; set; }

        /// <summary>
        /// Known values in <see cref="EnumValues.PageAppearance"/>
        /// </summary>
        [JsonPropertyName("page_appearance")]
        public string PageAppearance { get; set; }

        /// <summary>
        /// Known values in <see cref="EnumValues.PageLayout"/>
        /// </summary>
        [JsonPropertyName("page_layout")]
        public string PageLayout { get; set; }

        [JsonPropertyName("colors")]
        public PollThemeColor Colors { get; set; }

        [JsonPropertyName("option_colors")]
        [JsonConverter(typeof(StringArrayColorListConverter))]
        public List<Color> OptionColors { get; set; } = new List<Color>();

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
            if(other == null) return;
            
            Id = other.Id;
            Name = other.Name;
            PageAppearance = other.PageAppearance;
            PageLayout = other.PageLayout;
            Colors = other.Colors;
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
                   PageLayout == other.PageLayout && Colors == other.Colors &&
                   OptionColors.SequenceEqual(other.OptionColors) && BackToPollText == other.BackToPollText &&
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
                hashCode = (hashCode * 397) ^ (Colors != null ? Colors.GetHashCode() : 0);
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