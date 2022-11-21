using System;
using System.Drawing;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrawSharp.JsonConverters
{
    internal class StringColorConverter : JsonConverter<Color?>
    {
        public override Color? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // This string should never be null

            var str = reader.GetString();
            if (str == null) return null;

            str = str.Replace("#", "");
            if (str.Length < 6) str = str.PadRight(6, '0');

            var rHex = str.Substring(0, 2);
            var gHex = str.Substring(2, 2);
            var bHex = str.Substring(4, 2);

            var r = int.Parse(rHex, NumberStyles.HexNumber);
            var g = int.Parse(gHex, NumberStyles.HexNumber);
            var b = int.Parse(bHex, NumberStyles.HexNumber);
            
            return Color.FromArgb(r, g, b);
        }

        public override void Write(Utf8JsonWriter writer, Color? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
                return;
            }

            var val = value.Value;
            writer.WriteStringValue($"#{val.R:X2}{val.G:X2}{val.B:X2}");
        }
    }
}
