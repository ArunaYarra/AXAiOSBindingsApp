using Microsoft.Extensions.Logging;

namespace AXAiOSBindingsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureLifecycleEvents(events =>
            {
#if IOS
                events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) =>
                {
                    LogEvent(nameof(iOSLifecycle.FinishedLaunching));
                    AXAiOSBindings_MAUI.CAMDOReporter.InitializeSDKWithOptions(AXAiOSBindings_MAUI.SDKOptions.SDKLogLevelVerbose, (_, __) => {
                    {
                        LogEvent("SDK initialised successfully");
                    });
                   return true;
                }));

                //Microsoft.Maui.Handlers.WebViewHandler.PlatformViewFactory = (handler) =>
                //{
                //    WKWebViewConfiguration config = MauiWKWebView.CreateConfiguration();
                //    config.ApplicationNameForUserAgent = "MAAKitchenSink/1.0.0";
                //    return new MauiWKWebView(CGRect.Empty, (WebViewHandler)handler, config);
                //};
#else
                events.AddAndroid(android => android.OnRestart((activity) =>
                {
                    LogEvent(nameof(AndroidLifecycle.OnRestart));
                    System.Diagnostics.Debug.WriteLine("Registered", "Registered for App Feedback ");
                    //CaMDOIntegration.RegisterAppFeedBack(new Feedback());
                }));
#endif
                static bool LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                    return true;
                }
            })
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
