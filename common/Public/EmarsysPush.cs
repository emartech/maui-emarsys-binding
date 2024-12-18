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

	#if IOS
	public void SetDelegate()
	{
		_internal.SetDelegate();
	}
	#endif

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_internal.SetEventHandler(eventHandler);
	}

	#if ANDROID
	public Task<ErrorType?> SetPushToken(string pushToken)
	#elif IOS
	public Task<ErrorType?> SetPushToken(NSData pushToken)
	#endif
	{
		return _internal.SetPushToken(pushToken);
	}

	public Task<ErrorType?> ClearPushToken()
	{
		return _internal.ClearPushToken();
	}

	public string? GetPushToken()
	{
		return _internal.GetPushToken();
	}

	#if ANDROID
	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return _internal.HandleMessage(context, message);
	}
	#elif IOS
	public void HandleMessage(NSDictionary userInfo)
	{
		_internal.HandleMessage(userInfo);
	}
	#endif

	#if IOS
	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		_internal.DidReceiveNotificationRequest(request, contentHandler);
	}
	#endif

	#if IOS
	public void TimeWillExpire()
	{
		_internal.TimeWillExpire();
	}
	#endif

}
