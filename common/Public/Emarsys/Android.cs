namespace EmarsysBinding;

using Android.App;
using Android.Content;

public partial class Emarsys
{

	public static Task<ErrorType?> TrackDeepLink(Activity activity, Intent intent)
	{
		return _internal.TrackDeepLink(activity, intent);
	}

}
