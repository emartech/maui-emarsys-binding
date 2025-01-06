namespace EmarsysBinding.Internal;

#if ANDROID
using OnResultCallbackAction = System.Action<Message?, Java.Lang.Throwable?>;
#elif IOS
using OnResultCallbackAction = System.Action<Foundation.NSArray, Foundation.NSError?>;
#endif

public interface IPlatformAPIInbox
{
	public void FetchMessages(OnResultCallbackAction resultCallback);
	public void AddTag(string tag, string messageId, OnCompletedAction onCompleted);
	public void RemoveTag(string tag, string messageId, OnCompletedAction onCompleted);
}
