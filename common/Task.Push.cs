namespace EmarsysBinding;

#if ANDROID
using Java.Lang;
using EmarsysAndroid;
#elif IOS
using Foundation;
using EmarsysiOS;
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
		DotnetEmarsys.Push.SetPushToken(pushToken, Utils.CompletionListener((error) =>
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
		DotnetEmarsys.Push.ClearPushToken(Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

}
