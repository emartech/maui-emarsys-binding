namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public partial class PlatformAPIInbox
{

	public void FetchMessages(Action<List<Message>?, ErrorType?> onCompleted)
	{
		DotnetEmarsysInbox.FetchMessages((messages, error) =>
		{
			onCompleted(MessageMapper.Map(messages), error == null ? null : new Exception(error.Description));
		});
	}

}
