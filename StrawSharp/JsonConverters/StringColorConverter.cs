using System;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrawSharp.JsonConverters
{
    internal class StringColorConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // This string should never be null
            var str = reader.GetString();
            var spl = str.Split(',').Select(x => x.Trim());
            var values = spl.Select(x => int.Parse(x)).ToArray();
            int r = values[0], g = values[1], b = values[2];

            return Color.FromArgb(r, g, b);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.R}, {value.G}, {value.B}");
        }
    }
}
