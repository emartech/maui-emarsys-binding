namespace EmarsysBinding.Internal;

#if ANDROID
using Android.App;
#elif IOS
#endif

public class InternalAPIConfig(IPlatformAPIConfig platform)
{

	private readonly IPlatformAPIConfig _platform = platform;

	#if ANDROID
	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
	{
		return _platform.Build(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
	}
	#elif IOS
	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return _platform.Build(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}
	#else
	public bool Build(string? applicationCode, string? merchantId, bool enableConsoleLogging)
	{
		return _platform.Build(applicationCode, merchantId, enableConsoleLogging);
	}
	#endif

	public Task<ErrorType?> ChangeApplicationCode(string? applicationCode)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.ChangeApplicationCode(applicationCode, onCompleted);
		});
	}

	public Task<ErrorType?> ChangeMerchantId(string? merchantId)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.ChangeMerchantId(merchantId, onCompleted);
		});
	}

	public string? GetApplicationCode()
	{
		return _platform.GetApplicationCode();
	}

	public string? GetMerchantId()
	{
		return _platform.GetMerchantId();
	}

	public string GetClientId()
	{
		return _platform.GetClientId();
	}

	public string GetLanguageCode()
	{
		return _platform.GetLanguageCode();
	}

	public string GetSdkVersion()
	{
		return _platform.GetSdkVersion();
	}

	public int? GetContactFieldId()
	{
		return _platform.GetContactFieldId();
	}

}
