namespace EmarsysBinding.Internal;

public partial class PlatformAPIConfig
{

	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging)
	{
		return DotnetEmarsysConfig.Build(applicationCode, merchantId, sharedKeychainAccessGroup, enableConsoleLogging);
	}

}
