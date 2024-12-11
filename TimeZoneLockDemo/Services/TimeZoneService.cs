using System;

namespace TimeZoneLockDemo.Services
{
    public class TimeZoneService
    {
        private readonly TimeZoneInfo _targetTimeZone;

        public TimeZoneService(string timeZoneId)
        {
            _targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }

        public DateTime ConvertToTargetTimeZone(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTime(dateTime, _targetTimeZone);
        }

        public string FormatDateTime(DateTime dateTime)
        {
            var targetTime = ConvertToTargetTimeZone(dateTime);
            return targetTime.ToString("f");
        }
    }
}
