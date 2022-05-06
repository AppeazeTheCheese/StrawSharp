using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using StrawSharp.Models.Enums;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.JsonConverters
{
    internal class PollOptionConverter : JsonConverter<List<PollOption>>
    {
        public override List<PollOption> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var doc = JsonDocument.ParseValue(ref reader))
            {
                var pollOptions = new List<PollOption>();
                foreach (var option in doc.RootElement.EnumerateArray())
                {
                    var pollOption = option.Deserialize<PollOption>();
                    switch (pollOption.Type)
                    {
                        case OptionType.Text:
                            pollOptions.Add(option.Deserialize<TextPollOption>());
                            break;
                        case OptionType.Image:
                            pollOptions.Add(option.Deserialize<ImagePollOption>());
                            break;
                        case OptionType.Date:
                            pollOptions.Add(option.Deserialize<DatePollOption>());
                            break;
                        case OptionType.TimeRange:
                            pollOptions.Add(option.Deserialize<TimeRangePollOption>());
                            break;
                        default:
                            pollOptions.Add(pollOption);
                            break;
                    }
                }

                return pollOptions;
            }
        }

        public override void Write(Utf8JsonWriter writer, List<PollOption> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var option in value)
            {
                string rawValue;
                switch (option.Type)
                {
                    case OptionType.Text:
                        rawValue = JsonSerializer.Serialize((TextPollOption)option);
                        break;
                    case OptionType.Image:
                        rawValue = JsonSerializer.Serialize((ImagePollOption)option);
                        break;
                    case OptionType.Date:
                        rawValue = JsonSerializer.Serialize((DatePollOption)option);
                        break;
                    case OptionType.TimeRange:
                        rawValue = JsonSerializer.Serialize((TimeRangePollOption)option);
                        break;
                    default:
                        rawValue = JsonSerializer.Serialize(option);
                        break;
                }

                writer.WriteRawValue(rawValue);
            }
            writer.WriteEndArray();
        }
    }
}
