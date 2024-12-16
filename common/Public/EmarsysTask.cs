namespace EmarsysBinding;

public class EmarsysTask
{

	public static Task<ErrorType?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		Emarsys.TrackCustomEvent(eventName, eventAttributes, (error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	public static EmarsysTaskPush Push = new EmarsysTaskPush();

}
