namespace EmarsysCommon;

#if ANDROID
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using Emarsys = EmarsysiOS.DotnetEmarsys;
#endif

public class PushTask
{

	#if ANDROID
	public static Task<Java.Lang.Throwable?> SetPushToken (string pushToken)
	{
		var cs = new TaskCompletionSource<Java.Lang.Throwable?>();
	#elif IOS
	public static Task<Foundation.NSError?> SetPushToken (NSData pushToken)
	{
		var cs = new TaskCompletionSource<Foundation.NSError?>();
	#endif
		Emarsys.SetPushToken(pushToken, Utils.OnCompleted((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

}
