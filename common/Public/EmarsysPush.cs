namespace EmarsysBinding;

#if ANDROID
using Android.Content;
using Firebase.Messaging;
#elif IOS
using Foundation;
using UserNotifications;
#endif

public class EmarsysPush
{

	private static InternalAPIPush _internal = new InternalAPIPush(new PlatformAPIPush());

	public void SetEventHandler(EventHandlerAction handleEvent)
	{
		_internal.SetEventHandler(handleEvent);
	}

	#if ANDROID
	public Task<ErrorType?> SetPushToken(string pushToken)
	#elif IOS
	public Task<ErrorType?> SetPushToken(NSData pushToken)
	#endif
	{
		return _internal.SetPushToken(pushToken);
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
