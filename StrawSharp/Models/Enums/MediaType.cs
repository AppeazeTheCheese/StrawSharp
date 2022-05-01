using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
    public enum MediaType
    {
        [EnumMember(Value = "image")]
        Image,
        [EnumMember(Value = "video")]
        Video,
        [EnumMember(Value = "youtube")]
        YouTube,
        [EnumMember(Value = "giphy")]
        Giphy
    }
}
