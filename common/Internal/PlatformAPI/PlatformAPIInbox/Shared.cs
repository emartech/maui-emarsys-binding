namespace EmarsysBinding.Internal;

public partial class PlatformAPIInbox : IPlatformAPIInbox
{

	public void AddTag(string tag, string messageId, OnCompletedAction onCompleted)
	{
		DotnetEmarsysInbox.AddTag(tag, messageId, PlatformUtils.CompletionListener(onCompleted));
	}

	public void RemoveTag(string tag, string messageId, OnCompletedAction onCompleted)
	{
		DotnetEmarsysInbox.RemoveTag(tag, messageId, PlatformUtils.CompletionListener(onCompleted));
	}

}
