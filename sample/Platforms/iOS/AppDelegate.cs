using Foundation;
using UIKit;
using UserNotifications;
using Emarsys = EmarsysBindingiOS.DotnetEmarsys;
using EmarsysEventListener = EmarsysBindingiOS.EmarsysEventListener;
using MauiAppApplication = Microsoft.Maui.Controls.Application;

namespace sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	{
		Emarsys.Setup("EMSF3-5F5C2", "102F6519FC312033");
		Emarsys.SetEventListener(new MyEmarsysEventListener());

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

public class MyEmarsysEventListener : EmarsysEventListener
{
	override public void OnEvent(string eventName, NSDictionary? payload)
	{
		var payloadString = payload?.Description ?? "No payload";
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await MauiAppApplication.Current.MainPage.DisplayAlert("Notification Event", $"Event: {eventName}\nData: {payloadString}", "OK");
		});
	}
}