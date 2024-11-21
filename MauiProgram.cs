using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.LifecycleEvents;

namespace AXAiOSBindingsApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			// .ConfigureLifecycleEvents(events => {
			// 	// #if IOS || MACCATALYST
            //     //     events.AddiOS(ios => ios
            //     //         .OnActivated((app) => LogEvent(nameof(iOSLifecycle.OnActivated)))
            //     //         .OnResignActivation((app) => LogEvent(nameof(iOSLifecycle.OnResignActivation)))
            //     //         .DidEnterBackground((app) => LogEvent(nameof(iOSLifecycle.DidEnterBackground)))
            //     //         .WillTerminate((app) => LogEvent(nameof(iOSLifecycle.WillTerminate)))
			// 	// .FinishedLaunching((app, launchOptions) =>
            //     // {
            //     //     LogEvent(nameof(iOSLifecycle.FinishedLaunching));
			// 	// 	// AXAiOSBindings_MAUI.CAMDOReporter.InitializeSDKWithOptions(AXAiOSBindings_MAUI.SDKOptions.SDKLogLevelVerbose, (p1, p2) => {

			// 	// 	// });
			// 	// 	// AXAiOSBindings_MAUI.CAMDOReporter.InitializeSDKWithOptions(AXAiOSBindings_MAUI.SDKOptions.SDKLogLevelVerbose, (_, __) => {
   			// 	// 	// 	LogEvent("SDK initialized successfully");  
   			// 	// 	// }); 
			// 	// 	LogEvent("Initialisation done");
			// 	// 	// AXAiOSBindings_MAUI.CAMDOReporter.UploadEventsWithCompletionHandler((_, __) => {});
   			// 	// 	return true; 
            //     // }));
			// 	// #endif
			// 	static bool LogEvent(string eventName, string type = null)
			// 	{
            //         System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
            //         return true;
            //     }
			// })
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
