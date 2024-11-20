using Foundation;
using UIKit;
using UserNotifications;
using Emarsys = EmarsysiOS.DotnetEmarsys;
using EmarsysTask = EmarsysCommon.Task;
using EmarsysUtils = EmarsysCommon.Utils;

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

		UNUserNotificationCenter.Current.GetNotificationSettings((settings) =>
		{
			MainThread.BeginInvokeOnMainThread(() =>
			{
				if (settings.AuthorizationStatus == UNAuthorizationStatus.NotDetermined)
				{
					UIApplication.SharedApplication.RegisterForRemoteNotifications();
				}
				UNUserNotificationCenter.Current.RequestAuthorization(
					UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge,
					(approved, err) =>
					{
						Console.WriteLine("Push notification permission " + (approved ? "approved" : "denied"));
					}
				);
			});
		});

		return base.FinishedLaunching(application, launchOptions);
	}

	[Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
	public async void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
	{
		Console.WriteLine("Received native push token");
		switch (Utils.EmarsysResultMode) 
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.Push.SetPushToken(deviceToken);
				Utils.LogResult("SetPushToken T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.Push.SetPushToken(deviceToken, EmarsysUtils.CompletionListener((error) =>
				{
					Utils.LogResult("SetPushToken CL", error);
				}));
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.Push.SetPushToken(deviceToken);
				Utils.LogResult("SetPushToken");
				break;
		}
	}

	[Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
	public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
	{
		Console.WriteLine("Failed to receive native push token");
	}
}
