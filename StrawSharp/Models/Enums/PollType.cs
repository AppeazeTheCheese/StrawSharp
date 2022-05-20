using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Unknown)]
    public enum PollType
    {
        [EnumMember(Value = "multiple_choice")]
        MultipleChoice,
        [EnumMember(Value = "meeting")]
        Meeting,
        [EnumMember(Value = "ranked_choice")]
        RankedChoice,
        [EnumMember(Value = "anonymous_poll")]
        Anonymous,
        /// <summary>
        /// This is a fallback in case a poll has an unknown type. This is not an actual poll type.
        /// </summary>
        [Obsolete("This is not an actual poll type, it is only used as a fallback.")]
        [EnumMember]
        Unknown
    }
}
