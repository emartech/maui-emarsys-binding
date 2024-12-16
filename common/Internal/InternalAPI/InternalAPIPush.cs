namespace EmarsysBinding.Internal;

#if ANDROID
using Android.Content;
using Firebase.Messaging;
#elif IOS
using Foundation;
using UserNotifications;
#endif

public class InternalAPIPush(IPlatformAPIPush platform)
{

	private readonly IPlatformAPIPush _platform = platform;

	#if IOS || !ANDROID
	public void SetDelegate()
	{
		_platform.SetDelegate();
	}
	#endif

	public void SetEventHandler(EventHandlerAction handleEvent)
	{
		_platform.SetEventHandler(handleEvent);
	}

	#if ANDROID
	public Task<ErrorType?> SetPushToken(string pushToken)
	#elif IOS
	public Task<ErrorType?> SetPushToken(NSData pushToken)
	#else
	public Task<ErrorType?> SetPushToken(string pushToken)
	#endif
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.SetPushToken(pushToken, onCompleted);
		});
	}

	public Task<ErrorType?> ClearPushToken()
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.ClearPushToken(onCompleted);
		});
	}

	public string? GetPushToken()
	{
		return _platform.GetPushToken();
	}

	#if ANDROID
	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return _platform.HandleMessage(context, message);
	}
	#elif IOS
	public void HandleMessage(NSDictionary userInfo)
	{
		_platform.HandleMessage(userInfo);
	}
	#else
	public void HandleMessage(string message)
	{
		_platform.HandleMessage(message);
	}
	#endif

	#if IOS
	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		_platform.DidReceiveNotificationRequest(request, contentHandler);
	}
	#elif !ANDROID
	public void DidReceiveNotificationRequest(string request)
	{
		_platform.DidReceiveNotificationRequest(request);
	}
	#endif

	#if IOS || !ANDROID
	public void TimeWillExpire()
	{
		_platform.TimeWillExpire();
	}
	#endif

}
