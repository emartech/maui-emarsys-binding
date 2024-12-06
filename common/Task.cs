namespace EmarsysBinding;

public class EmarsysTask
{

	public static Task<ErrorType?> SetContact(int contactFieldId, string contactFieldValue)
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		Emarsys.SetContact(contactFieldId, contactFieldValue, (error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	public static Task<ErrorType?> ClearContact()
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		Emarsys.ClearContact((error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	public static Task<ErrorType?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		Emarsys.TrackCustomEvent(eventName, eventAttributes, (error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	public static TaskPush Push = new TaskPush();

}
