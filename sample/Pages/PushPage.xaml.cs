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
		var error = await Emarsys.Push.SetPushToken(pushToken);
		Utils.LogResult("SetPushToken", error);
		#elif IOS
		UIKit.UIApplication.SharedApplication.RegisterForRemoteNotifications();
		#endif
	}

	private async void OnClearPushTokenClicked(object sender, EventArgs e)
	{
		var error = await Emarsys.Push.ClearPushToken();
		Utils.LogResult("ClearPushToken", error);
	}

	private void OnGetPushTokenClicked(object sender, EventArgs e)
	{
		var pushToken = Emarsys.Push.GetPushToken();
		Utils.LogResult("GetPushToken", null, pushToken);
	}

}
