namespace EmarsysBinding;

using Foundation;

public partial class Emarsys
{

	public static bool TrackDeepLink(NSUserActivity userActivity, Action<NSString>? sourceHandler = null)
	{
		return _internal.TrackDeepLink(userActivity, sourceHandler);
	}

}
