namespace EmarsysBinding;

#if ANDROID
using Java.Lang;
using Android.App;
using System.Collections.Generic;
using EmarsysAndroid;
#elif IOS
using Foundation;
using EmarsysiOS;
#endif

public class Emarsys
{

	#if ANDROID
	public static DotnetEMSConfig Config(Application application, string? applicationCode, string? merchantId, IList<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
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

	#if ANDROID
	public static void SetContact(int contactFieldId, string contactFieldValue, Action<Throwable?>? onCompleted = null)
	#elif IOS
	public static void SetContact(int contactFieldId, string contactFieldValue, Action<NSError?>? onCompleted = null)
	#endif
	{
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, Utils.CompletionListener(onCompleted));
	}

	#if ANDROID
	public static void ClearContact(Action<Throwable?>? onCompleted = null)
	#elif IOS
	public static void ClearContact(Action<NSError?>? onCompleted = null)
	#endif
	{
		DotnetEmarsys.ClearContact(Utils.CompletionListener(onCompleted));
	}

	public static Push Push = new Push();

}
