namespace EmarsysCommon;

#if ANDROID
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using Emarsys = EmarsysiOS.DotnetEmarsys;
#endif

public class TaskPush
{

	#if ANDROID
	public Task<Java.Lang.Throwable?> SetPushToken(string pushToken)
	{
		var cs = new TaskCompletionSource<Java.Lang.Throwable?>();
	#elif IOS
	public Task<Foundation.NSError?> SetPushToken(Foundation.NSData pushToken)
	{
		var cs = new TaskCompletionSource<Foundation.NSError?>();
	#endif
		Emarsys.Push.SetPushToken(pushToken, Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	#if ANDROID
	public Task<Java.Lang.Throwable?> ClearPushToken()
	{
		var cs = new TaskCompletionSource<Java.Lang.Throwable?>();
	#elif IOS
	public Task<Foundation.NSError?> ClearPushToken()
	{
		var cs = new TaskCompletionSource<Foundation.NSError?>();
	#endif
		Emarsys.Push.ClearPushToken(Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

}
