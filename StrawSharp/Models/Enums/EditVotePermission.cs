using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Nobody)]
    public enum EditVotePermission
    {
        [EnumMember(Value = "nobody")]
        Nobody,
        [EnumMember(Value = "admin")]
        Admin,
        [EnumMember(Value = "admin_voter")]
        AdminVoter,
        [EnumMember(Value = "voter")]
        Voter,
        [EnumMember(Value = "everybody")]
        Everybody
    }
}