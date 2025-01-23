namespace EmarsysBinding.Internal;

using Java.Lang;
using EmarsysBinding.Model;

public partial class PlatformAPIInbox
{

	public void FetchMessages(Action<List<EMSMessage>?, ErrorType?> onCompleted)
	{
		DotnetEmarsysInbox.FetchMessages(new FetchMessagesResultCallback((messages, error) =>
		{
			onCompleted(MessageMapper.Map(messages), error);
		}));
	}

}

class FetchMessagesResultCallback(Action<IList<IDictionary<string, Object>>?, Throwable?> action) : Object, DotnetEmarsysInbox.IFetchMessagesResultCallback
{

	private readonly Action<IList<IDictionary<string, Object>>?, Throwable?> _action = action;

	public void OnResult(IList<IDictionary<string, Object>>? messages, Throwable? error)
	{
		_action.Invoke(messages, error);
	}

}
