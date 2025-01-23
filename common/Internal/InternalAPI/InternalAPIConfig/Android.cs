namespace EmarsysBinding.Internal;

using Android.App;

public partial class InternalAPIConfig
{

	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging)
	{
		return _platform.Build(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
	}

}
