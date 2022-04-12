using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Free)]
    public enum UserSubscription
    {
        [EnumMember(Value = "free")]
        Free,
        [EnumMember(Value = "pro")]
        Pro
    }
}
