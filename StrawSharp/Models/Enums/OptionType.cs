using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
    public enum OptionType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "image")]
        Image,
        [EnumMember(Value = "date")]
        Date,
        [EnumMember(Value = "time_range")]
        TimeRange
    }
}
