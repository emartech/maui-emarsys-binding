namespace EmarsysBinding.Internal;

using Android.App;

public partial interface IPlatformAPIConfig
{

	public EMSConfig Build(Application application, string? applicationCode, string? merchantId, List<string>? sharedPackageNames, string? sharedSecret, bool enableConsoleLogging);

}
