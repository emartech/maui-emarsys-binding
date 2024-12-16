namespace EmarsysBinding;

#if ANDROID
using Android.App;
using Android.Content;
#elif IOS
using Foundation;
#endif

public class Emarsys
{

	private static InternalAPI _internal = new InternalAPI(new PlatformAPI());

	public static void Setup(EMSConfig config)
	{
		_internal.Setup(config);
		
		TrackCustomEvent("wrapper:init", new Dictionary<string, string>
		{
			{ "type", "maui" }
		});
	}

	public static Task<ErrorType?> SetContact(int contactFieldId, string contactFieldValue)
	{
		return _internal.SetContact(contactFieldId, contactFieldValue);
	}

	public static Task<ErrorType?> ClearContact()
	{
		return _internal.ClearContact();
	}

	public static Task<ErrorType?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes = null)
	{
		return _internal.TrackCustomEvent(eventName, eventAttributes);
	}

	#if ANDROID
	public static Task<ErrorType?> TrackDeepLink(Activity activity, Intent intent)
	{
		return _internal.TrackDeepLink(activity, intent);
	}
	#elif IOS
	public static bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler = null)
	{
		return _internal.TrackDeepLink(userActivity, sourceHandler);
	}
	#endif

	public static EmarsysConfig Config = new EmarsysConfig();

	public static EmarsysPush Push = new EmarsysPush();

	public static EmarsysInApp InApp = new EmarsysInApp();

}
