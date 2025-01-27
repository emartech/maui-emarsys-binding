namespace EmarsysBinding.Internal;

public partial class InternalAPIConfig
{

	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return _platform.Build(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}

}
