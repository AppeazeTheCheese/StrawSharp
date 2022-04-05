using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Always)]
    public enum ResultVisibility
    {
        [EnumMember(Value = "always")]
        Always,
        [EnumMember(Value = "after_deadline")]
        AfterDeadline,
        [EnumMember(Value = "hidden")]
        Never
    }
}