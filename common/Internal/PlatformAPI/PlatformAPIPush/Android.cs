namespace EmarsysBinding.Internal;

using Android.Content;
using Firebase.Messaging;

public partial class PlatformAPIPush
{

	public void SetPushToken(string pushToken, OnCompletedAction onCompleted)
	{
		DotnetEmarsysPush.SetPushToken(pushToken, PlatformUtils.CompletionListener(onCompleted));
	}

	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return DotnetEmarsysPush.HandleMessage(context, message);
	}

}
