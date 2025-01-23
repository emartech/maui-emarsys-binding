namespace EmarsysBinding.Internal;

public partial interface IPlatformAPIConfig
{

	public void ChangeApplicationCode(string? applicationCode, OnCompletedAction onCompleted);

	public void ChangeMerchantId(string? merchantId, OnCompletedAction onCompleted);

	public string? GetApplicationCode();

	public string? GetMerchantId();

	public string GetClientId();

	public string GetLanguageCode();

	public string GetSdkVersion();

	public int? GetContactFieldId();

}
