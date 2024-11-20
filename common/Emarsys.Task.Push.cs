namespace EmarsysCommon;

#if ANDROID
using Java.Lang;
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using Foundation;
using Emarsys = EmarsysiOS.DotnetEmarsys;
#endif

public class TaskPush
{

	#if ANDROID
	public Task<Throwable?> SetPushToken(string pushToken)
	{
		var cs = new TaskCompletionSource<Throwable?>();
	#elif IOS
	public Task<NSError?> SetPushToken(NSData pushToken)
	{
		var cs = new TaskCompletionSource<NSError?>();
	#endif
		Emarsys.Push.SetPushToken(pushToken, Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	#if ANDROID
	public Task<Throwable?> ClearPushToken()
	{
		var cs = new TaskCompletionSource<Throwable?>();
	#elif IOS
	public Task<NSError?> ClearPushToken()
	{
		var cs = new TaskCompletionSource<NSError?>();
	#endif
		Emarsys.Push.ClearPushToken(Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

}
