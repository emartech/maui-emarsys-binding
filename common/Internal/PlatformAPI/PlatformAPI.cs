namespace EmarsysBinding.Internal;

public class PlatformAPI: IPlatformAPI
{

	public void Setup(EMSConfig config)
	{
		DotnetEmarsys.Setup(config);
	}

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction? onCompleted)
	{
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, Utils.CompletionListener(onCompleted));
	}

	public void ClearContact(OnCompletedAction? onCompleted)
	{
		DotnetEmarsys.ClearContact(Utils.CompletionListener(onCompleted));
	}

	public void TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes, OnCompletedAction? onCompleted)
	{
		DotnetEmarsys.TrackCustomEvent(eventName, Utils.ToNativeDictionary(eventAttributes), Utils.CompletionListener(onCompleted));
	}

	#if ANDROID
	public void TrackDeepLink(Activity activity, Intent intent, Action<ErrorType?>? onCompleted)
	{
		DotnetEmarsys.TrackDeepLink(activity, intent, Utils.CompletionListener(onCompleted));
	}
	#elif IOS
	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler)
	{
		return DotnetEmarsys.TrackDeepLink(userActivity, sourceHandler);
	}
	#endif
}
