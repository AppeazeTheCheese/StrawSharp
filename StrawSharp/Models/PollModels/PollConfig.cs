using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models.PollModels
{
    public class PollConfig
    {
        [JsonPropertyName("vote_type")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public VoteType VoteType { get; set; } = VoteType.Default;

        [JsonPropertyName("allow_comments")]
        public bool AllowComments { get; set; } = false;

        [JsonPropertyName("allow_indeterminate")]
        public bool AllowIndeterminate { get; set; } = false;

        [JsonPropertyName("allow_other_option")]
        public bool AllowOtherOption { get; set; } = false;

        [JsonPropertyName("allow_vpn_users")]
        public bool AllowVpn { get; set; } = false;

        [JsonPropertyName("custom_design_colors")]
        public PollCustomDesignColors CustomDesignColors { get; set; } = new PollCustomDesignColors();

        [JsonPropertyName("deadline_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Deadline { get; set; } = null;

        [JsonPropertyName("duplication_checking")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public DuplicationCheck DuplicationChecking { get; set; } = DuplicationCheck.None;

        [JsonPropertyName("edit_vote_permissions")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public EditVotePermission EditVotePermissions { get; set; } = EditVotePermission.Nobody;

        [JsonPropertyName("force_appearance")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public ForceAppearance ForceAppearance { get; set; } = ForceAppearance.Auto;

        [JsonPropertyName("hide_participants")]
        public bool HideParticipants { get; set; } = false;

        [JsonPropertyName("is_multiple_choice")]
        public bool IsMultipleChoice { get; set; } = false;

        [JsonPropertyName("is_private")]
        public bool IsPrivate { get; set; } = false;

        [JsonPropertyName("multiple_choice_min")]
        public int? MinChoices { get; set; } = null;

        [JsonPropertyName("multiple_choice_max")]
        public int? MaxChoices { get; set; } = null;

        [JsonPropertyName("number_of_winners")]
        public int? Winners { get; set; }

        [JsonPropertyName("randomize_options")] 
        public bool RandomizeOptions { get; set; } = false;

        [JsonPropertyName("require_voter_names")]
        public bool RequireName { get; set; } = false;

        [JsonPropertyName("results_visibility")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public ResultVisibility ResultVisibility { get; set; } = ResultVisibility.Always;

        [JsonPropertyName("use_custom_design")] 
        public bool UseCustomDesign { get; set; } = false;

        protected bool Equals(PollConfig other)
        {
            return AllowComments == other.AllowComments && AllowIndeterminate == other.AllowIndeterminate &&
                   AllowOtherOption == other.AllowOtherOption && AllowVpn == other.AllowVpn &&
                   Equals(CustomDesignColors, other.CustomDesignColors) && Nullable.Equals(Deadline, other.Deadline) &&
                   DuplicationChecking == other.DuplicationChecking &&
                   EditVotePermissions == other.EditVotePermissions && ForceAppearance == other.ForceAppearance &&
                   HideParticipants == other.HideParticipants && IsMultipleChoice == other.IsMultipleChoice &&
                   IsPrivate == other.IsPrivate && MinChoices == other.MinChoices && MaxChoices == other.MaxChoices &&
                   Winners == other.Winners && RandomizeOptions == other.RandomizeOptions &&
                   RequireName == other.RequireName && ResultVisibility == other.ResultVisibility &&
                   UseCustomDesign == other.UseCustomDesign && VoteType == other.VoteType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PollConfig) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AllowComments.GetHashCode();
                hashCode = (hashCode * 397) ^ AllowIndeterminate.GetHashCode();
                hashCode = (hashCode * 397) ^ AllowOtherOption.GetHashCode();
                hashCode = (hashCode * 397) ^ AllowVpn.GetHashCode();
                hashCode = (hashCode * 397) ^ (CustomDesignColors != null ? CustomDesignColors.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Deadline.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)DuplicationChecking;
                hashCode = (hashCode * 397) ^ (int)EditVotePermissions;
                hashCode = (hashCode * 397) ^ (int)ForceAppearance;
                hashCode = (hashCode * 397) ^ HideParticipants.GetHashCode();
                hashCode = (hashCode * 397) ^ IsMultipleChoice.GetHashCode();
                hashCode = (hashCode * 397) ^ IsPrivate.GetHashCode();
                hashCode = (hashCode * 397) ^ MinChoices.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxChoices.GetHashCode();
                hashCode = (hashCode * 397) ^ Winners.GetHashCode();
                hashCode = (hashCode * 397) ^ RandomizeOptions.GetHashCode();
                hashCode = (hashCode * 397) ^ RequireName.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)ResultVisibility;
                hashCode = (hashCode * 397) ^ UseCustomDesign.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)VoteType;
                return hashCode;
            }
        }

        public static bool operator ==(PollConfig left, PollConfig right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PollConfig left, PollConfig right)
        {
            return !Equals(left, right);
        }
    }
}