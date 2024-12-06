namespace EmarsysBinding;

#if ANDROID
#elif IOS
using Foundation;
#endif

public class TaskPush
{

	#if ANDROID
	public Task<ErrorType?> SetPushToken(string pushToken)
	#elif IOS
	public Task<ErrorType?> SetPushToken(NSData pushToken)
	#endif
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		Emarsys.Push.SetPushToken(pushToken, (error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	public Task<ErrorType?> ClearPushToken()
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		Emarsys.Push.ClearPushToken((error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

}
