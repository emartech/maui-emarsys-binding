namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public partial class PlatformAPIInbox: IPlatformAPIInbox
{

	public void FetchMessages(Action<List<EMSMessage>?, ErrorType?> onCompleted)
	{
		DotnetEmarsysInbox.FetchMessages((messages, error) =>
		{
			onCompleted(MessageMapper.Map(messages), error);
		});
	}

}
