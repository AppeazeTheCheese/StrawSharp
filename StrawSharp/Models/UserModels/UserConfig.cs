using System;
using System.Text.Json.Serialization;
using StrawSharp.JsonConverters;

namespace StrawSharp.Models.UserModels
{
    public class UserConfig
    {
        [JsonPropertyName("appearance")]
        public string Appearance { get; set; }

        [JsonPropertyName("clock_type")]
        public string ClockType { get; set; }

        [JsonPropertyName("first_day_of_week")]
        public DayOfWeek FirstDayOfWeek { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("notification_delay")]
        public int NotificationDelay { get; set; }

        [JsonPropertyName("notify_deadline")]
        public bool NotifyDeadline { get; set; }

        [JsonPropertyName("notify_meeting_vote")]
        public bool NotifyMeetingVote { get; set; }

        [JsonPropertyName("notify_poll_vote")]
        public bool NotifyPollVote { get; set; }

        [JsonPropertyName("timezone")]
        [JsonConverter(typeof(StringTimeZoneInfoConverter))]
        public TimeZoneInfo TimeZone { get; set; }

        protected bool Equals(UserConfig other)
        {
            return Appearance == other.Appearance && ClockType == other.ClockType &&
                   FirstDayOfWeek == other.FirstDayOfWeek && Language == other.Language && Locale == other.Locale &&
                   NotificationDelay == other.NotificationDelay && NotifyDeadline == other.NotifyDeadline &&
                   NotifyMeetingVote == other.NotifyMeetingVote && NotifyPollVote == other.NotifyPollVote &&
                   Equals(TimeZone, other.TimeZone);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserConfig)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Appearance != null ? Appearance.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ClockType != null ? ClockType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)FirstDayOfWeek;
                hashCode = (hashCode * 397) ^ (Language != null ? Language.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Locale != null ? Locale.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NotificationDelay;
                hashCode = (hashCode * 397) ^ NotifyDeadline.GetHashCode();
                hashCode = (hashCode * 397) ^ NotifyMeetingVote.GetHashCode();
                hashCode = (hashCode * 397) ^ NotifyPollVote.GetHashCode();
                hashCode = (hashCode * 397) ^ (TimeZone != null ? TimeZone.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UserConfig left, UserConfig right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserConfig left, UserConfig right)
        {
            return !Equals(left, right);
        }
    }
}
