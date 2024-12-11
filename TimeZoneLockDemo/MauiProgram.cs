using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using TimeZoneLockDemo.Services;
using Microsoft.Extensions.DependencyInjection;
using TimeZoneLockDemo.ViewModels;

namespace TimeZoneLockDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddSingleton<IndianTimeZoneService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
