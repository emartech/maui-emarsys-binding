namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public interface IPlatformAPIInbox
{

	public void FetchMessages(Action<List<EMSMessage>?, ErrorType?> onCompleted);

	public void AddTag(string tag, string messageId, OnCompletedAction onCompleted);

	public void RemoveTag(string tag, string messageId, OnCompletedAction onCompleted);

}
