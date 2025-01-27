namespace EmarsysBinding.Internal;

using Foundation;

public partial interface IPlatformAPI
{

	public bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler);

}
