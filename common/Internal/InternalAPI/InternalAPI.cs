namespace EmarsysBinding.Internal;

public class InternalAPI(IPlatformAPI platform)
{

	private readonly IPlatformAPI _platform = platform;

	#if ANDROID || IOS
	public void Setup(EMSConfig config)
	#else
	public void Setup(string config)
	#endif
	{
		_platform.Setup(config);
	}

	public Task<ErrorType?> SetContact(int contactFieldId, string contactFieldValue)
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.SetContact(contactFieldId, contactFieldValue, onCompleted);
		});
	}

	public Task<ErrorType?> ClearContact()
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.ClearContact(onCompleted);
		});
	}

	public Task<ErrorType?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.TrackCustomEvent(eventName, eventAttributes, onCompleted);
		});
	}

	#if ANDROID
	public Task<ErrorType?> TrackDeepLink(Activity activity, Intent intent)
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.TrackDeepLink(activity, intent, onCompleted);
		});
	}
	#elif IOS
	public Task<ErrorType?> TrackDeepLink(NSUserActivity userActivity)
	{
		return Utils.Task((sourceHandler) =>
		{
			_platform.TrackDeepLink(userActivity, sourceHandler);
		});
	}
	#else
	public Task<ErrorType?> TrackDeepLink(string userActivity)
	{
		return Utils.Task((sourceHandler) =>
		{
			_platform.TrackDeepLink(userActivity, sourceHandler);
		});
	}
	#endif
}
