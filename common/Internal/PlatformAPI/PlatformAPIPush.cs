namespace EmarsysBinding.Internal;

#if ANDROID
using Android.Content;
using Firebase.Messaging;
#elif IOS
using Foundation;
using UserNotifications;
#endif

public class PlatformAPIPush: IPlatformAPIPush
{

	public void SetEventHandler(EventHandlerAction handleEvent)
	{
		DotnetEmarsysPush.SetEventHandler(Utils.EventHandler(handleEvent));
	}

	#if ANDROID
	public void SetPushToken(string pushToken, OnCompletedAction? onCompleted)
	#elif IOS
	public void SetPushToken(NSData pushToken, OnCompletedAction? onCompleted)
	#endif
	{
		DotnetEmarsysPush.SetPushToken(pushToken, Utils.CompletionListener(onCompleted));
	}

}
