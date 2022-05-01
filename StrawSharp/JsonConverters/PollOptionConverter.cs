using System;
using System.Collections.Generic;
using System.Security;
using System.Text.Json;
using System.Text.Json.Nodes;
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
                        case PollType.Text:
                            pollOptions.Add(option.Deserialize<TextPollOption>());
                            break;
                        case PollType.Image:
                            pollOptions.Add(option.Deserialize<ImagePollOption>());
                            break;
                        case PollType.Date:
                            pollOptions.Add(option.Deserialize<DatePollOption>());
                            break;
                        case PollType.TimeRange:
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
                    case PollType.Text:
                        rawValue = JsonSerializer.Serialize((TextPollOption)option);
                        break;
                    case PollType.Image:
                        rawValue = JsonSerializer.Serialize((ImagePollOption)option);
                        break;
                    case PollType.Date:
                        rawValue = JsonSerializer.Serialize((DatePollOption)option);
                        break;
                    case PollType.TimeRange:
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

        //public override void Write(Utf8JsonWriter writer, PollOption value, JsonSerializerOptions options)
        //{
        //    string rawValue;
        //    switch (value.Type)
        //    {
        //        case PollType.Text:
        //            rawValue = JsonSerializer.Serialize((TextPollOption)value);
        //            break;
        //        case PollType.Image:
        //            rawValue = JsonSerializer.Serialize((ImagePollOption)value);
        //            break;
        //        case PollType.Date:
        //            rawValue = JsonSerializer.Serialize((DatePollOption)value);
        //            break;
        //        case PollType.TimeRange:
        //            rawValue = JsonSerializer.Serialize((TimeRangePollOption)value);
        //            break;
        //        default:
        //            rawValue = JsonSerializer.Serialize(value);
        //            break;
        //    }

        //    writer.WriteRawValue(rawValue);
        //}
    }
}
