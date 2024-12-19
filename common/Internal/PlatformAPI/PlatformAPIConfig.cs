namespace EmarsysBinding.Internal;

#if ANDROID
using Android.App;
#elif IOS
#endif

public class PlatformAPIConfig: IPlatformAPIConfig
{

	#if ANDROID
	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
	{
		return DotnetEmarsysConfig.Build(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
	}
	#elif IOS
	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return DotnetEmarsysConfig.Build(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}
	#endif

	public void ChangeApplicationCode(string? applicationCode, OnCompletedAction onCompleted)
	{
		DotnetEmarsysConfig.ChangeApplicationCode(applicationCode, PlatformUtils.CompletionListener(onCompleted));
	}

}
