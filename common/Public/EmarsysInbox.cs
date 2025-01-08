namespace EmarsysBinding;

using EmarsysBinding.Model;

public class EmarsysInbox
{

	private static InternalAPIInbox _internal = new InternalAPIInbox(new PlatformAPIInbox());

	public Task<(List<Message>? Messages, ErrorType? Error)> FetchMessages()
	{
		return _internal.FetchMessages();
	}
	
	public Task<ErrorType?> AddTag(string tag, string messageId)
	{
		return _internal.AddTag(tag, messageId);
	}

	public Task<ErrorType?> RemoveTag(string tag, string messageId)
	{
		return _internal.RemoveTag(tag, messageId);
	}
}
