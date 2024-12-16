namespace EmarsysBinding;

#if ANDROID
#elif IOS
using Foundation;
#endif

public class EmarsysTaskPush
{

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
