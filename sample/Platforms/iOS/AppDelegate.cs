using Foundation;
using UIKit;
using UserNotifications;
using Emarsys = EmarsysiOS.DotnetEmarsys;
using MauiAppApplication = Microsoft.Maui.Controls.Application;

namespace sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	{
		Emarsys.Setup("EMSF3-5F5C2", "102F6519FC312033");
		Emarsys.PushEventHandler = (eventName, payload) =>
		{
			var payloadString = payload?.Description ?? "No payload";
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				await MauiAppApplication.Current.MainPage.DisplayAlert("Notification Event", $"Event: {eventName}\nData: {payloadString}", "OK");
			});
		};

		UNUserNotificationCenter.Current.RequestAuthorization(
			UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge,
			(approved, err) =>
			{
				if (approved)
				{
					InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
				}
				else
				{
					Console.WriteLine("Push notification permission denied");
				}
			});

		return base.FinishedLaunching(application, launchOptions);
	}

	[Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
	public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
	{
		Console.WriteLine("Received native push token");
		Emarsys.SetPushToken(deviceToken);
	}


	[Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
	public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
	{
		Console.WriteLine("Failed to receive native push token");
	}
}
