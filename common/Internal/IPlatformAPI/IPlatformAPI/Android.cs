namespace EmarsysBinding.Internal;

using Android.App;
using Android.Content;

public partial interface IPlatformAPI
{

	public void TrackDeepLink(Activity activity, Intent intent, OnCompletedAction onCompleted);

}
