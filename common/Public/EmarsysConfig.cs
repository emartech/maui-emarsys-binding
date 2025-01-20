namespace EmarsysBinding;

#if ANDROID
using Android.App;
#elif IOS
#endif

public class EmarsysConfig
{

	private static InternalAPIConfig _internal = new InternalAPIConfig(new PlatformAPIConfig());

	#if ANDROID
	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
	{
		return _internal.Build(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
	}
	#elif IOS
	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return _internal.Build(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}
	#endif

	public Task<ErrorType?> ChangeApplicationCode(string? applicationCode)
	{
		return _internal.ChangeApplicationCode(applicationCode);
	}

	public Task<ErrorType?> ChangeMerchantId(string? merchantId)
	{
		return _internal.ChangeMerchantId(merchantId);
	}

	public string? GetApplicationCode()
	{
		return _internal.GetApplicationCode();
	}

	public string? GetMerchantId()
	{
		return _internal.GetMerchantId();
	}

	public string GetClientId()
	{
		return _internal.GetClientId();
	}

	public string GetLanguageCode()
	{
		return _internal.GetLanguageCode();
	}

	public string GetSdkVersion()
	{
		return _internal.GetSdkVersion();
	}

	public int? GetContactFieldId()
	{
		return _internal.GetContactFieldId();
	}

}
