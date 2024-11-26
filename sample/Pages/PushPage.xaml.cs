namespace sample;

#if ANDROID
using Firebase.Messaging;
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using UIKit;
using Emarsys = EmarsysiOS.DotnetEmarsys;
#endif
using EmarsysTask = EmarsysCommon.Task;
using EmarsysUtils = EmarsysCommon.Utils;

public partial class PushPage : ContentPage
{

	public PushPage()
	{
		InitializeComponent();
	}

	private async void OnSetPushTokenClicked(object sender, EventArgs e)
	{
		#if ANDROID
		var pushToken = FirebaseMessaging.Instance.GetToken().Result.ToString();
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.Push.SetPushToken(pushToken);
				Utils.LogResult("SetPushToken T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.Push.SetPushToken(pushToken, EmarsysUtils.CompletionListener((error) =>
				{
					Utils.LogResult("SetPushToken CL", error);
				}));
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.Push.PushToken = pushToken;
				Utils.LogResult("SetPushToken");
				break;
		}
		#elif IOS
		UIApplication.SharedApplication.RegisterForRemoteNotifications();
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
				Emarsys.Push.ClearPushToken(EmarsysUtils.CompletionListener((error) =>
				{
					Utils.LogResult("ClearPushToken CL", error);
				}));
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.Push.ClearPushToken();
				Utils.LogResult("ClearPushToken");
				break;
		}
	}

	private void OnGetPushTokenClicked(object sender, EventArgs e)
	{
		var pushToken = Emarsys.Push.PushToken;
		Utils.LogResult("GetPushToken", null, pushToken);
	}

}
