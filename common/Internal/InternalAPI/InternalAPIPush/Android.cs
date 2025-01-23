namespace EmarsysBinding.Internal;

using Android.Content;
using Firebase.Messaging;

public partial class InternalAPIPush
{

	public Task<ErrorType?> SetPushToken(string pushToken)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.SetPushToken(pushToken, onCompleted);
		});
	}

	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return _platform.HandleMessage(context, message);
	}

}
