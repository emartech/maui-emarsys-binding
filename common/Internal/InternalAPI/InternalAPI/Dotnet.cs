namespace EmarsysBinding.Internal;

public partial class InternalAPI
{

	public void TrackDeepLink(string activity)
	{
		_platform.TrackDeepLink(activity);
	}

}
