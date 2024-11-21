using Foundation;
using UIKit;

namespace AXAiOSBindingsApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
		AXAiOSBindings_MAUI.CAMDOReporter.InitializeSDKWithOptions(AXAiOSBindings_MAUI.SDKOptions.SDKLogLevelVerbose, (_, __) => {
   			System.Console.WriteLine("SDK initialized successfully");  
   		});
        return base.FinishedLaunching(application, launchOptions);
    }
}
