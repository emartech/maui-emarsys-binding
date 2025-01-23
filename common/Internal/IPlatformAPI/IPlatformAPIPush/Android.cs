namespace EmarsysBinding.Internal;

using Android.Content;
using Firebase.Messaging;

public partial interface IPlatformAPIPush
{

	public void SetPushToken(string pushToken, OnCompletedAction onCompleted);

	public bool HandleMessage(Context context, RemoteMessage message);

}
