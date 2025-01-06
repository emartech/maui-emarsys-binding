namespace EmarsysBinding.Internal;

#if ANDROID
using OnResultCallbackAction = System.Action<EmarsysAndroid.EMSMessage?, Java.Lang.Throwable?>;
#elif IOS
using OnResultCallbackAction = System.Action<Foundation.NSArray, Foundation.NSError?>;
using Foundation;
// using MessageList = Foundation.NSArray<Message>;
#endif

public class InternalAPIInbox(IPlatformAPIInbox platform)
{

	private readonly IPlatformAPIInbox _platform = platform;

	public Task<List<Message>?> FetchMessages()
	{
		var tcs = new TaskCompletionSource<List<Message>?>();

		_platform.FetchMessages((messages, error) =>
		{
			if (error != null)
			{
				Console.WriteLine($"Error fetching messages: {error}");
				tcs.SetResult(null);
				// tcs.SetException(new Exception($"Error fetching messages: {error}"));
			}
			else
			{
				tcs.SetResult(MessageMapper.MapInbox(messages));
			}
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
