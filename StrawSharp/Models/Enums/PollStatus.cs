using System.Text.Json.Serialization;

namespace StrawSharp.Models.Enums
{
    [JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: Published)]
    public enum PollStatus
    {
        Draft,
        Published,
        Blocked
    }
}
