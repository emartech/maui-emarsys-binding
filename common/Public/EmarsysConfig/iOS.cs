namespace EmarsysBinding;

public partial class EmarsysConfig
{

	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return _internal.Build(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}

}
