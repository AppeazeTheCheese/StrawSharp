using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.EnumValues;

namespace StrawSharp.Models.PollModels
{
    public class PollConfig
    {
        [JsonPropertyName("allow_comments")]
        public bool AllowComments { get; set; }

        [JsonPropertyName("allow_indeterminate")]
        public bool AllowIndeterminate { get; set; }

        [JsonPropertyName("allow_other_option")]
        public bool AllowOtherOption { get; set; }

        [JsonPropertyName("allow_vpn_users")]
        public bool AllowVpn { get; set; }

        [JsonPropertyName("deadline_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// The type of duplication checking for this poll. Known values in <see cref="DuplicationCheck"/>.
        /// </summary>
        [JsonPropertyName("duplication_checking")]
        public string DuplicationChecking { get; set; } = DuplicationCheck.None;

        /// <summary>
        /// Who has access to edit votes for this poll. <see cref="EditVotePermission"/>
        /// </summary>
        [JsonPropertyName("edit_vote_permissions")]
        public string EditVotePermissions { get; set; } = EditVotePermission.Nobody;

        /// <summary>
        /// Which appearance to force when viewing the poll. Known values in <see cref="EnumValues.ForceAppearance"/>.
        /// </summary>
        [JsonPropertyName("force_appearance")]
        public string ForceAppearance { get; set; } = EnumValues.ForceAppearance.Auto;

        [JsonPropertyName("hide_participants")]
        public bool HideParticipants { get; set; }

        [JsonPropertyName("is_multiple_choice")]
        public bool IsMultipleChoice { get; set; }
        
        /// <summary>
        /// The layout of the poll. Known values in <see cref="PollLayout"/>.
        /// </summary>
        [JsonPropertyName("layout")]
        public string Layout { get; set; }
        
        [JsonPropertyName("multiple_choice_min")]
        public int? MinChoices { get; set; }

        [JsonPropertyName("multiple_choice_max")]
        public int? MaxChoices { get; set; }

        [JsonPropertyName("number_of_winners")]
        public int? Winners { get; set; }

        [JsonPropertyName("randomize_options")]
        public bool RandomizeOptions { get; set; }

        [JsonPropertyName("require_voter_names")]
        public bool RequireName { get; set; }

        /// <summary>
        /// When the results will become visible. Known values in <see cref="EnumValues.ResultVisibility"/>.
        /// </summary>
        [JsonPropertyName("results_visibility")]
        public string ResultVisibility { get; set; } = EnumValues.ResultVisibility.Always;

        public PollConfig() { }

        public PollConfig(PollConfig other)
        {
            if (other == null) return;
            AllowComments = other.AllowComments;
            AllowIndeterminate = other.AllowIndeterminate;
            AllowOtherOption = other.AllowOtherOption;
            AllowVpn = other.AllowVpn;
            Deadline = other.Deadline;
            DuplicationChecking = other.DuplicationChecking;
            EditVotePermissions = other.EditVotePermissions;
            ForceAppearance = other.ForceAppearance;
            HideParticipants = other.HideParticipants;
            IsMultipleChoice = other.IsMultipleChoice;
            MinChoices = other.MinChoices;
            MaxChoices = other.MaxChoices;
            Winners = other.Winners;
            RandomizeOptions = other.RandomizeOptions;
            RequireName = other.RequireName;
            ResultVisibility = other.ResultVisibility;
        }

        protected bool Equals(PollConfig other)
        {
            return AllowComments == other.AllowComments && AllowIndeterminate == other.AllowIndeterminate &&
                   AllowOtherOption == other.AllowOtherOption && AllowVpn == other.AllowVpn &&
                   Nullable.Equals(Deadline, other.Deadline) &&
                   DuplicationChecking == other.DuplicationChecking &&
                   EditVotePermissions == other.EditVotePermissions && ForceAppearance == other.ForceAppearance &&
                   HideParticipants == other.HideParticipants && IsMultipleChoice == other.IsMultipleChoice &&
                   MinChoices == other.MinChoices && MaxChoices == other.MaxChoices &&
                   Winners == other.Winners && RandomizeOptions == other.RandomizeOptions &&
                   RequireName == other.RequireName && ResultVisibility == other.ResultVisibility;
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
                hashCode = (hashCode * 397) ^ Deadline.GetHashCode();
                hashCode = (hashCode * 397) ^ (DuplicationChecking != null ? DuplicationChecking.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EditVotePermissions != null ? EditVotePermissions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ForceAppearance != null ? ForceAppearance.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HideParticipants.GetHashCode();
                hashCode = (hashCode * 397) ^ IsMultipleChoice.GetHashCode();
                hashCode = (hashCode * 397) ^ MinChoices.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxChoices.GetHashCode();
                hashCode = (hashCode * 397) ^ Winners.GetHashCode();
                hashCode = (hashCode * 397) ^ RandomizeOptions.GetHashCode();
                hashCode = (hashCode * 397) ^ RequireName.GetHashCode();
                hashCode = (hashCode * 397) ^ (ResultVisibility != null ? ResultVisibility.GetHashCode() : 0);
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