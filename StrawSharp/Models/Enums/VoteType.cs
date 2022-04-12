using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Default)]
    public enum VoteType
    {
        [EnumMember(Value = "default")]
        Default,
        [EnumMember(Value = "box_small")]
        BoxSmall,
        [EnumMember(Value = "participant_grid")]
        ParticipantGrid,
        [EnumMember(Value = "drag")]
        Drag,
        [EnumMember(Value = "grid")]
        Grid
    }
}
