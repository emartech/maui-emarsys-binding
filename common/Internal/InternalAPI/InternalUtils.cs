namespace EmarsysBinding.Internal;

using Foundation;

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
}
