using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrawSharp.JsonConverters
{
    public class StringArrayColorListConverter : JsonConverter<List<Color>>
    {
        public override List<Color> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var doc = JsonDocument.ParseValue(ref reader))
            {
                var colors = new List<Color>();
                foreach (var elem in doc.RootElement.EnumerateArray())
                {
                    var str = elem.GetString();
                    if(str == null) continue;
                    
                    str = str.Replace("#", "");
                    if (str.Length < 6) str = str.PadRight(6, '0');

                    var rHex = str.Substring(0, 2);
                    var gHex = str.Substring(2, 2);
                    var bHex = str.Substring(4, 2);

                    var r = int.Parse(rHex, NumberStyles.HexNumber);
                    var g = int.Parse(gHex, NumberStyles.HexNumber);
                    var b = int.Parse(bHex, NumberStyles.HexNumber);
                    
                    colors.Add(Color.FromArgb(r, g, b));
                }

                return colors;
            }
        }

        public override void Write(Utf8JsonWriter writer, List<Color> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var color in value)
            {
                writer.WriteStringValue($"#{color.R:X2}{color.G:X2}{color.B:X2}");
            }
            
            writer.WriteEndArray();
        }
    }
}