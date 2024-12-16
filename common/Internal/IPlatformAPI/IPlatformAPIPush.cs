namespace EmarsysBinding.Internal;

#if ANDROID
using Android.Content;
using Firebase.Messaging;
#elif IOS
using Foundation;
using UserNotifications;
#endif

public interface IPlatformAPIPush
{

	public void SetEventHandler(EventHandlerAction handleEvent);

	#if ANDROID
	public void SetPushToken(string pushToken, OnCompletedAction? onCompleted);
	#elif IOS
	public void SetPushToken(NSData pushToken, OnCompletedAction? onCompleted);
	#else
	public void SetPushToken(string pushToken, OnCompletedAction? onCompleted);
	#endif

}
