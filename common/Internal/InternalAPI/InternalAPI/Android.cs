namespace EmarsysBinding.Internal;

using Android.App;
using Android.Content;

public partial class InternalAPI
{

	public Task<ErrorType?> TrackDeepLink(Activity activity, Intent intent)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.TrackDeepLink(activity, intent, onCompleted);
		});
	}

}
