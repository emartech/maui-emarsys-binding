namespace EmarsysBinding.Internal;

public class InternalAPIInbox(IPlatformAPIInbox platform)
{

	private readonly IPlatformAPIInbox _platform = platform;

	public Task<CallbackType?> FetchMessages()
	{
		return InternalUtils.TaskFromCallback((callback) =>
		{
			_platform.FetchMessages(callback);
		});
	}

	public Task<ErrorType?> AddTag(string tag, string messageId)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.AddTag(tag, messageId, onCompleted);
		});
	}

	public Task<ErrorType?> RemoveTag(string tag, string messageId)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.RemoveTag(tag, messageId, onCompleted);
		});
	}
}
