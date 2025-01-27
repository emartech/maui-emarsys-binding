namespace EmarsysBinding.Internal;

public partial class PlatformAPIConfig : IPlatformAPIConfig
{

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
