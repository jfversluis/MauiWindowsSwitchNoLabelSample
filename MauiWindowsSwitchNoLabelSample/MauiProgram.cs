using Microsoft.Extensions.Logging;

namespace MauiWindowsSwitchNoLabelSample
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

#if WINDOWS
            Microsoft.Maui.Handlers.SwitchHandler.Mapper.AppendToMapping("NoLabel", (handler, view) =>
            {
                // Remove this if statement if you want to apply this to all switches
                if (view is MyCustomSwitch)
                {
                    handler.PlatformView.OnContent = null;
                    handler.PlatformView.OffContent = null;

                    // Add this to remove the padding around the switch as well
                    // handler.PlatformView.MinWidth = 0;
                }
            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
