using Foundation;
using UIKit;
using UserNotifications;
using Emarsys = EmarsysiOS.DotnetEmarsys;

namespace sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	{
		var config = Emarsys.Config("EMSF3-5F5C2", "102F6519FC312033", null, true);
		Emarsys.Setup(config);
		Emarsys.Push.SetDelegate();
		Emarsys.Push.SetEventHandler((eventName, payload) =>
		{
			string payloadString = payload?.Description ?? "No payload";
			Utils.DisplayAlert("Notification Event", $"Event: {eventName}\nData: {payloadString}");
		});

		UIApplication.SharedApplication.RegisterForRemoteNotifications();
		UNUserNotificationCenter.Current.RequestAuthorization(
			UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge,
			(approved, err) =>
			{
				Console.WriteLine("Push notification permission " + (approved ? "approved" : "denied"));
			}
		);

		return base.FinishedLaunching(application, launchOptions);
	}

	[Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
	public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
	{
		Console.WriteLine("Received native push token");
		Emarsys.Push.SetPushToken(deviceToken);
	}


	[Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
	public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
	{
		Console.WriteLine("Failed to receive native push token");
	}
}
