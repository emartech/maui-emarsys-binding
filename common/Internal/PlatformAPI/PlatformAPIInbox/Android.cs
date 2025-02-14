namespace EmarsysBinding.Internal;

using Java.Lang;
using EmarsysBinding.Model;

public partial class PlatformAPIInbox
{

	public void FetchMessages(Action<List<EMSMessage>?, ErrorType?> onCompleted)
	{
		DotnetEmarsysInbox.FetchMessages(new FetchMessagesResultCallback(onCompleted));
	}

}

class FetchMessagesResultCallback(Action<List<EMSMessage>?, ErrorType?> action) : Object, DotnetEmarsysInbox.IFetchMessagesResultCallback
{

	private readonly Action<List<EMSMessage>?, ErrorType?> _action = action;

	public void OnResult(IList<IDictionary<string, Object>>? messages, Throwable? error)
	{
		_action.Invoke(MessageMapper.Map(messages), error == null ? null : new Exception(error.Message));
	}

}
