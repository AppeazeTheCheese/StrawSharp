using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
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