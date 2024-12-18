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

	#if IOS
	public void SetDelegate()
	{
		DotnetEmarsysPush.SetDelegate();
	}
	#endif

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysPush.SetEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

	#if ANDROID
	public void SetPushToken(string pushToken, OnCompletedAction onCompleted)
	#elif IOS
	public void SetPushToken(NSData pushToken, OnCompletedAction onCompleted)
	#endif
	{
		DotnetEmarsysPush.SetPushToken(pushToken, PlatformUtils.CompletionListener(onCompleted));
	}

	public void ClearPushToken(OnCompletedAction onCompleted)
	{
		DotnetEmarsysPush.ClearPushToken(PlatformUtils.CompletionListener(onCompleted));
	}

	public string? GetPushToken()
	{
		return DotnetEmarsysPush.PushToken;
	}

	#if ANDROID
	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return DotnetEmarsysPush.HandleMessage(context, message);
	}
	#elif IOS
	public void HandleMessage(NSDictionary userInfo)
	{
		DotnetEmarsysPush.HandleMessage(userInfo);
	}
	#endif

	#if IOS
	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		DotnetEmarsysPush.DidReceiveNotificationRequest(request, contentHandler);
	}
	#endif

	#if IOS
	public void TimeWillExpire()
	{
		DotnetEmarsysPush.TimeWillExpire();
	}
	#endif

}
