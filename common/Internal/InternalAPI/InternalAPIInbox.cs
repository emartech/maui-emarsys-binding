namespace EmarsysBinding.Internal;

#if ANDROID

#elif IOS
using Foundation;
#endif
using EmarsysBinding.Model;

public class InternalAPIInbox(IPlatformAPIInbox platform)
{

	private readonly IPlatformAPIInbox _platform = platform;

	public Task<(List<Message>? Messages, ErrorType? Error)> FetchMessages()
	{
		var tcs = new TaskCompletionSource<(List<Message>?, ErrorType?)>();

		_platform.FetchMessages((messages, error) =>
		{
			#if ANDROID
			tcs.SetResult((messages, error));
			#elif IOS
			tcs.SetResult((MessageMapper.MapInbox(messages), error));
			#endif
		});

		return tcs.Task;
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
