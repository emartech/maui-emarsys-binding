namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public class InternalAPIInbox(IPlatformAPIInbox platform)
{

	private readonly IPlatformAPIInbox _platform = platform;

	public Task<(List<Message>? Messages, ErrorType? Error)> FetchMessages()
	{
		var cs = new TaskCompletionSource<(List<Message>?, ErrorType?)>();
		_platform.FetchMessages((messages, error) =>
		{
			cs.SetResult((messages, error));
		});
		return cs.Task;
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
