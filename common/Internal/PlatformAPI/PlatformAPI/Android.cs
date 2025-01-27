namespace EmarsysBinding.Internal;

using Android.App;
using Android.Content;

public partial class PlatformAPI
{

	public void TrackDeepLink(Activity activity, Intent intent, OnCompletedAction onCompleted)
	{
		DotnetEmarsys.TrackDeepLink(activity, intent, PlatformUtils.CompletionListener(onCompleted));
	}

}
