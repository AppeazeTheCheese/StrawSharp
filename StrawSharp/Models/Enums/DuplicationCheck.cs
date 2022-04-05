using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: None)]
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