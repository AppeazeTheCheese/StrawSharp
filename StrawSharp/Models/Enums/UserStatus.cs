﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Active)]
    public enum UserStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "banned")]
        Banned
    }
}
