using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Auto)]
    public enum ForceAppearance
    {
        [EnumMember(Value = "light")]
        Light,
        [EnumMember(Value = "dark")]
        Dark,
        [EnumMember(Value = "auto")]
        Auto
    }
}
