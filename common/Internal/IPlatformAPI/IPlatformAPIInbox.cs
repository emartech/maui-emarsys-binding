namespace EmarsysBinding.Internal;

public interface IPlatformAPIInbox
{
	public void AddTag(string tag, string messageId, OnCompletedAction onCompleted);
	public void RemoveTag(string tag, string messageId, OnCompletedAction onCompleted);
}
