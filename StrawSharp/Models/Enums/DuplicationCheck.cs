using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
    public enum DuplicationCheck
    {
        [EnumMember(Value = "ip")]
        Ip,
        [EnumMember(Value = "session")]
        Session,
        [EnumMember(Value = "none")]
        None
    }
}