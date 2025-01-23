namespace EmarsysBinding.Internal;

#if ANDROID
using Android.App;
#elif IOS
#endif

public interface IPlatformAPIConfig
{

	#if ANDROID
	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging);
	#elif IOS
	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging);
	#else
	public string Build(string? applicationCode, string? merchantId, bool enableConsoleLogging);
	#endif

	public void ChangeApplicationCode(string? applicationCode, OnCompletedAction onCompleted);

	public void ChangeMerchantId(string? merchantId, OnCompletedAction onCompleted);

	public string? GetApplicationCode();

	public string? GetMerchantId();

	public string GetClientId();

	public string GetLanguageCode();

	public string GetSdkVersion();

	public int? GetContactFieldId();

}
