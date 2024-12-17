namespace EmarsysBinding.Internal;

public interface IPlatformAPI
{

	#if ANDROID || IOS
	public void Setup(EMSConfig config);
	#else
	public void Setup(string config);
	#endif

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction? onCompleted);

	public void ClearContact(OnCompletedAction? onCompleted);

	public void TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes, OnCompletedAction? onCompleted);

	#if ANDROID
	public void TrackDeepLink(Activity activity, Intent intent, Action<ErrorType?>? onCompleted);
	#elif IOS
	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler);
	#else
	public bool TrackDeepLink(string userActivity, Action<string?>? sourceHandler);
	#endif
}
