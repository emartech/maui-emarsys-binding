namespace EmarsysBinding.Internal;

#if ANDROID
using OnResultCallbackAction = System.Action<EmarsysAndroid.EMSMessage?, Java.Lang.Throwable?>;
#elif IOS
using OnResultCallbackAction = System.Action<Foundation.NSArray?, Foundation.NSError?>;
#endif

public class PlatformAPIInbox: IPlatformAPIInbox
{

	public void FetchMessages(OnResultCallbackAction resultCallback)
	{
		DotnetEmarsysInbox.FetchMessages(PlatformUtils.ResultCallback(resultCallback));
	}

	public void AddTag(string tag, string messageId, OnCompletedAction onCompleted)
	{
		DotnetEmarsysInbox.AddTag(tag, messageId, PlatformUtils.CompletionListener(onCompleted));
	}

	public void RemoveTag(string tag, string messageId, OnCompletedAction onCompleted)
	{
		DotnetEmarsysInbox.RemoveTag(tag, messageId, PlatformUtils.CompletionListener(onCompleted));
	}


}
