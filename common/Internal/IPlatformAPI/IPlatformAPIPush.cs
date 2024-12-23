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

	#if IOS || !ANDROID
	public void SetDelegate();
	#endif

	public void SetEventHandler(EventHandlerAction eventHandler);

	#if ANDROID || !IOS
	public void SetPushToken(string pushToken, OnCompletedAction onCompleted);
	#elif IOS
	public void SetPushToken(NSData pushToken, OnCompletedAction onCompleted);
	#endif

	public void ClearPushToken(OnCompletedAction onCompleted);

	public string? GetPushToken();

	#if ANDROID
	public bool HandleMessage(Context context, RemoteMessage message);
	#elif IOS
	public void HandleMessage(NSDictionary userInfo);
	#else
	public void HandleMessage(string message);
	#endif

	#if IOS
	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler);
	#elif !ANDROID
	public void DidReceiveNotificationRequest(string request);
	#endif

	#if IOS || !ANDROID
	public void TimeWillExpire();
	#endif

	public void SetSilentMessageEventHandler(EventHandlerAction eventHandler);
}
