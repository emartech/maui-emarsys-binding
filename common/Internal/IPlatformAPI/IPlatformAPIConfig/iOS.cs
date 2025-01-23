namespace EmarsysBinding.Internal;

public partial interface IPlatformAPIConfig
{

	public EMSConfig Build(string? applicationCode, string? merchantId, string? sharedKeychainAccessGroup, bool enableConsoleLogging);

}
