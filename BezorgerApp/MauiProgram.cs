using Microsoft.Extensions.Logging;
using BezorgerApp.Services;
using BezorgerApp.ViewModels;

namespace BezorgerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
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

            // Dependency injection
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddTransient<OrdersViewModel>();
            builder.Services.AddTransient<OrderDetailViewModel>();
            builder.Services.AddTransient<SignatureViewModel>();
            builder.Services.AddTransient<DeliveryOverviewViewModel>();
            builder.Services.AddTransient<MapViewModel>();

            return builder.Build();
        }
    }
}