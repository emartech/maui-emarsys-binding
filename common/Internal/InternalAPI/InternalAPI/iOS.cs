namespace EmarsysBinding.Internal;

using Foundation;

public partial class InternalAPI
{

	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler)
	{
		return _platform.TrackDeepLink(userActivity, sourceHandler);
	}

}
