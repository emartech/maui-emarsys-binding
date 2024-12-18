namespace EmarsysBinding.Internal;

#if ANDROID
using Android.App;
using Android.Content;
#elif IOS
using Foundation;
#endif

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
	public void TrackDeepLink(Activity activity, Intent intent, OnCompletedAction? onCompleted);
	#elif IOS
	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler);
	#else
	public void TrackDeepLink(string activity);
	#endif

}
