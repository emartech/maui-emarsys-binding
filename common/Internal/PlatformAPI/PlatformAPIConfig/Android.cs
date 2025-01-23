namespace EmarsysBinding.Internal;

using Android.App;

public partial class PlatformAPIConfig
{

	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
	{
		return DotnetEmarsysConfig.Build(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
	}

}
