namespace Sample;

using EmarsysBinding;

public partial class PushPage : ContentPage
{

	public PushPage()
	{
		InitializeComponent();
	}

	private async void OnSetPushTokenClicked(object sender, EventArgs e)
	{
		#if ANDROID
		var pushToken = Firebase.Messaging.FirebaseMessaging.Instance.GetToken().Result.ToString();
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.Push.SetPushToken(pushToken);
				Utils.LogResult("SetPushToken T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.Push.SetPushToken(pushToken, (error) =>
				{
					Utils.LogResult("SetPushToken CL", error);
				});
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.Push.SetPushToken(pushToken);
				Utils.LogResult("SetPushToken");
				break;
		}
		#elif IOS
		UIKit.UIApplication.SharedApplication.RegisterForRemoteNotifications();
		#endif
	}

	private async void OnClearPushTokenClicked(object sender, EventArgs e)
	{
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.Push.ClearPushToken();
				Utils.LogResult("ClearPushToken T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.Push.ClearPushToken((error) =>
				{
					Utils.LogResult("ClearPushToken CL", error);
				});
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.Push.ClearPushToken();
				Utils.LogResult("ClearPushToken");
				break;
		}
	}

	private void OnGetPushTokenClicked(object sender, EventArgs e)
	{
		var pushToken = Emarsys.Push.GetPushToken();
		Utils.LogResult("GetPushToken", null, pushToken);
	}

}
