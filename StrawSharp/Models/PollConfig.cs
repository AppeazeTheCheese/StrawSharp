using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;
using StrawSharp.Models.Enums;

namespace StrawSharp.Models
{
    public class PollConfig
    {
        [JsonPropertyName("allow_comments")]
        public bool AllowComments { get; set; } = false;

        [JsonPropertyName("allow_indeterminate")]
        public bool AllowIndeterminate { get; set; } = false;

        [JsonPropertyName("allow_other_option")]
        public bool AllowOtherOption { get; set; } = false;

        [JsonPropertyName("allow_vpn_users")]
        public bool AllowVpn { get; set; } = false;

        [JsonPropertyName("custom_design_colors")] 
        public PollCustomDesignColors CustomDesignColors { get; set; } = null;

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
        [DefaultValue(null)]
        public int? MinChoices { get; set; } = null;

        [JsonPropertyName("multiple_choice_max")]
        [DefaultValue(null)]
        public int? MaxChoices { get; set; } = null;

        [JsonPropertyName("number_of_winners")]
        public int Winners { get; set; }

        [JsonPropertyName("randomize_options")] 
        public bool RandomizeOptions { get; set; } = false;

        [JsonPropertyName("require_voter_names")]
        public bool RequireName { get; set; } = false;

        [JsonPropertyName("results_visibility")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public ResultVisibility ResultVisibility { get; set; } = ResultVisibility.Always;

        [JsonPropertyName("use_custom_design")] 
        public bool UseCustomDesign { get; set; } = false;

        [JsonPropertyName("vote_type")]
        [DefaultValue("default")]
        public string VoteType { get; set; } = "default";
    }
}