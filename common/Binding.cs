namespace EmarsysBinding;

#if ANDROID
using Android.App;
using Android.Content;
#elif IOS
using Foundation;
#endif

public class Emarsys
{

	#if ANDROID
	public static DotnetEMSConfig Config(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
	{
		return DotnetEmarsys.Config(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
	}
	#elif IOS
	public static EMSConfig Config(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return DotnetEmarsys.Config(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}
	#endif

	#if ANDROID
	public static void Setup(DotnetEMSConfig config)
	#elif IOS
	public static void Setup(EMSConfig config)
	#endif
	{
		DotnetEmarsys.Setup(config);
	}

	public static void SetContact(int contactFieldId, string contactFieldValue, Action<ErrorType?>? onCompleted = null)
	{
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, Utils.CompletionListener(onCompleted));
	}

	public static void ClearContact(Action<ErrorType?>? onCompleted = null)
	{
		DotnetEmarsys.ClearContact(Utils.CompletionListener(onCompleted));
	}

	public static void TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes = null, Action<ErrorType?>? onCompleted = null)
	{
		DotnetEmarsys.TrackCustomEvent(eventName, Utils.ToNativeDictionary(eventAttributes), Utils.CompletionListener(onCompleted));
	}

	#if ANDROID
	public static void TrackDeepLink(Activity activity, Intent intent, Action<ErrorType?>? onCompleted = null)
	{
		DotnetEmarsys.TrackDeepLink(activity, intent, Utils.CompletionListener(onCompleted));
	}
	#elif IOS
	public static bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler = null)
	{
		return DotnetEmarsys.TrackDeepLink(userActivity, sourceHandler);
	}
	#endif

	public static Push Push = new Push();

	public static InApp InApp = new InApp();

}
