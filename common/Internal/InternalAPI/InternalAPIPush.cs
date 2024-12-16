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

}
