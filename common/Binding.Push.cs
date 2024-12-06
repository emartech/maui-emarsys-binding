namespace EmarsysBinding;

#if ANDROID
using Android.Content;
using Firebase.Messaging;
#elif IOS
using Foundation;
using UserNotifications;
#endif

public class Push
{

	public void SetEventHandler(EventHandlerAction handleEvent)
	{
		DotnetEmarsys.Push.SetEventHandler(Utils.EventHandler(handleEvent));
	}

	#if ANDROID
	public void SetPushToken(string pushToken, Action<ErrorType?>? onCompleted = null)
	#elif IOS
	public void SetPushToken(NSData pushToken, Action<ErrorType?>? onCompleted = null)
	#endif
	{
		DotnetEmarsys.Push.SetPushToken(pushToken, Utils.CompletionListener(onCompleted));
	}

	public void ClearPushToken(Action<ErrorType?>? onCompleted = null)
	{
		DotnetEmarsys.Push.ClearPushToken(Utils.CompletionListener(onCompleted));
	}

	public string? GetPushToken()
	{
		return DotnetEmarsys.Push.PushToken;
	}

	#if ANDROID
	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return DotnetEmarsys.Push.HandleMessage(context, message);
	}
	#elif IOS
	public void HandleMessage(NSDictionary userInfo)
	{
		DotnetEmarsys.Push.HandleMessage(userInfo);
	}
	#endif

	#if IOS
	public void SetDelegate()
	{
		DotnetEmarsys.Push.SetDelegate();
	}

	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		DotnetEmarsys.Push.DidReceiveNotificationRequest(request, contentHandler);
	}

	public void TimeWillExpire()
	{
		DotnetEmarsys.Push.TimeWillExpire();
	}
	#endif

}
