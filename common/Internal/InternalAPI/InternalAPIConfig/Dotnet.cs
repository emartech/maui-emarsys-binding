namespace EmarsysBinding.Internal;

public partial class InternalAPIConfig
{

	public string Build(string? applicationCode, string? merchantId, bool enableConsoleLogging)
	{
		return _platform.Build(applicationCode, merchantId, enableConsoleLogging);
	}

}
