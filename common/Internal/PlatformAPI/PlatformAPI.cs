namespace EmarsysBinding.Internal;

#if ANDROID
using Android.App;
using Android.Content;
#elif IOS
using Foundation;
#endif

public class PlatformAPI: IPlatformAPI
{

	public void Setup(EMSConfig config)
	{
		DotnetEmarsys.Setup(config);
	}

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction onCompleted)
	{
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, PlatformUtils.CompletionListener(onCompleted));
	}

	public void ClearContact(OnCompletedAction onCompleted)
	{
		DotnetEmarsys.ClearContact(PlatformUtils.CompletionListener(onCompleted));
	}

	public void TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes, OnCompletedAction onCompleted)
	{
		DotnetEmarsys.TrackCustomEvent(eventName, PlatformUtils.ToNativeDictionary(eventAttributes), PlatformUtils.CompletionListener(onCompleted));
	}

	#if ANDROID
	public void TrackDeepLink(Activity activity, Intent intent, OnCompletedAction onCompleted)
	{
		DotnetEmarsys.TrackDeepLink(activity, intent, PlatformUtils.CompletionListener(onCompleted));
	}
	#elif IOS
	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler)
	{
		return DotnetEmarsys.TrackDeepLink(userActivity, sourceHandler);
	}
	#endif

}
