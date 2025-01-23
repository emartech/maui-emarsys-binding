namespace EmarsysBinding.Internal;

public partial class InternalAPIConfig(IPlatformAPIConfig platform)
{

	private readonly IPlatformAPIConfig _platform = platform;

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
