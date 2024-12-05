using Foundation;
using UIKit;
using UserNotifications;
using EmarsysBinding;

namespace Sample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	{
		var config = Emarsys.Config("EMS12-04EC1", "1DF86BF95CBE8F19", null, true);
		Emarsys.Setup(config);
		Emarsys.Push.SetDelegate();

		Action<NSString, NSDictionary<NSString, NSObject>> eventHandler = (eventName, payload) =>
		{
			string payloadString = payload?.Description ?? "No payload";
			Utils.DisplayAlert("Handle event", $"Event: {eventName}\nPayload: {payloadString}");
		};
		Emarsys.Push.SetEventHandler(eventHandler);
		Emarsys.InApp.SetEventHandler(eventHandler);
		Emarsys.InApp.SetOnEventActionEventHandler(eventHandler);

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
				Emarsys.Push.SetPushToken(deviceToken, (error) =>
				{
					Utils.LogResult("SetPushToken CL", error);
				});
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
