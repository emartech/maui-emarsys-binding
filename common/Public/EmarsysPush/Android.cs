namespace EmarsysBinding;

using Android.Content;
using Firebase.Messaging;

public partial class EmarsysPush
{

	public Task<ErrorType?> SetPushToken(string pushToken)
	{
		return _internal.SetPushToken(pushToken);
	}

	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return _internal.HandleMessage(context, message);
	}

}
