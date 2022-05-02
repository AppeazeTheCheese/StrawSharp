using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
    public enum PollType
    {
        [EnumMember(Value = "multiple_choice")]
        MultipleChoice,
        [EnumMember(Value = "meeting")]
        Meeting,
        [EnumMember(Value = "ranked_choice")]
        RankedChoice
    }
}
