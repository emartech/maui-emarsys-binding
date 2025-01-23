namespace EmarsysBinding.Internal;

public partial interface IPlatformAPIConfig
{
	public string Build(string? applicationCode, string? merchantId, bool enableConsoleLogging);

}
