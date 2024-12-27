namespace EmarsysBinding.Internal;

class InternalUtils
{

	public static Task<ErrorType?> Task(Action<OnCompletedAction> callback)
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		callback((error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	public static Task<CallbackType?> TaskFromCallback(Action<Action<CallbackType?>> callback)
	{
		var taskCompletionSource = new TaskCompletionSource<CallbackType?>();
		
		callback(result =>
		{
			taskCompletionSource.SetResult(result);
		});
		return taskCompletionSource.Task;
	}

}
