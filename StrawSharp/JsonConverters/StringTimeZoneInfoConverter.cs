using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using TimeZoneConverter;

namespace StrawSharp.JsonConverters
{
    internal class StringTimeZoneInfoConverter : JsonConverter<TimeZoneInfo>
    {
        public override TimeZoneInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            if (string.IsNullOrWhiteSpace(str))
                return null;

            var convertedZone = str;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                convertedZone = TZConvert.IanaToWindows(str);

            return TimeZoneInfo.FindSystemTimeZoneById(convertedZone);
        }

        public override void Write(Utf8JsonWriter writer, TimeZoneInfo value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
