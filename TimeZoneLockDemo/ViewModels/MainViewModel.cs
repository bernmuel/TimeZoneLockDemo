using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeZoneLockDemo.Services;

namespace TimeZoneLockDemo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IndianTimeZoneService? _timeZoneService;

        [ObservableProperty]
        private string? eventTime;

        [ObservableProperty]
        private string? localTime;

        [ObservableProperty]
        private string? localTimeName;

        [ObservableProperty]
        private string? timeZoneName;

        public MainViewModel(IndianTimeZoneService? timeZoneService)
        {
            _timeZoneService = timeZoneService;
            SetEventTime(DateTime.Now);

            TimeZoneName = _timeZoneService?.GetTimeZoneName() ?? string.Empty;

            // Initialize local time
            UpdateLocalTime();

            LocalTimeName = _timeZoneService?.GetLocalTimeZoneName() ?? string.Empty;

            // Start timer for updating local time every minute
            //_timer = new Timer(60000); // 60 seconds
            //_timer.Elapsed += (s, e) => UpdateLocalTime();
            //_timer.Start();
        }

        [RelayCommand]
        public void Refresh()
        {
            SetEventTime(DateTime.Now);

            UpdateLocalTime();
        }

        private void SetEventTime(DateTime localTime)
        {
            EventTime = _timeZoneService?.FormatDateTime(localTime);
        }

        public void UpdateLocalTime()
        {
            LocalTime = DateTime.Now.ToString("f");
        }
    }
}
