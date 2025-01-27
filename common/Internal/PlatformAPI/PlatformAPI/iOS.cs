namespace EmarsysBinding.Internal;

using Foundation;

public partial class PlatformAPI
{

	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler)
	{
		return DotnetEmarsys.TrackDeepLink(userActivity, sourceHandler);
	}

}
