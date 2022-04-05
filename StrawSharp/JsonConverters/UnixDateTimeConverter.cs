using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrawSharp.JsonConverters
{
    public class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64()).LocalDateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(new DateTimeOffset(value).ToUnixTimeSeconds());
        }
    }
}
