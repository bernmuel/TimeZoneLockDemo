using System;


namespace TimeZoneLockDemo.Services
{
    public class IndianTimeZoneService
    {
        private readonly TimeZoneInfo _targetTimeZone;

        public IndianTimeZoneService()
        {
            _targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        }

        public DateTime ConvertToTargetTimeZone(DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }

            //return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, _targetTimeZone);

            var targetTime_forTesting = TimeZoneInfo.ConvertTimeFromUtc(dateTime, _targetTimeZone);
            return targetTime_forTesting;
        }

        public string FormatDateTime(DateTime dateTime)
        {
            var targetTime = ConvertToTargetTimeZone(dateTime);
            return targetTime.ToString("f");    // Example: Monday, December 10, 2024 5:30 PM
        }

        public string GetTimeZoneName()
        {
            return _targetTimeZone.DisplayName;  // Example: "(UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi"
        }

        public string GetLocalTimeZoneName()
        {
            return TimeZoneInfo.Local.DisplayName;  // Example: "(UTC-08:00) Pacific Time (US & Canada)"
        }
    }
}
