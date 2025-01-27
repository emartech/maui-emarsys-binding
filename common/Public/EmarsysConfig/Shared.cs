namespace EmarsysBinding;

public partial class EmarsysConfig
{

	private static InternalAPIConfig _internal = new InternalAPIConfig(new PlatformAPIConfig());

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

	public string GetMauiBindingVersion()
	{
		return Global.packageVersion;
	}

}
