namespace EmarsysBinding.Internal;

#if ANDROID
using Android.App;
#elif IOS
#endif

public class PlatformAPIConfig : IPlatformAPIConfig
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

	public void ChangeMerchantId(string? merchantId, OnCompletedAction onCompleted)
	{
		DotnetEmarsysConfig.ChangeMerchantId(merchantId, PlatformUtils.CompletionListener(onCompleted));
	}

	public string? GetApplicationCode()
	{
		return DotnetEmarsysConfig.ApplicationCode;
	}

	public string? GetMerchantId()
	{
		return DotnetEmarsysConfig.MerchantId;
	}

	public string GetClientId()
	{
		return DotnetEmarsysConfig.ClientId;
	}

	public string GetLanguageCode()
	{
		return DotnetEmarsysConfig.LanguageCode;
	}

	public string GetSdkVersion()
	{
		return DotnetEmarsysConfig.SdkVersion;
	}

	public int? GetContactFieldId()
	{
		return DotnetEmarsysConfig.ContactFieldId != null ? (int) DotnetEmarsysConfig.ContactFieldId : null;
	}

}
