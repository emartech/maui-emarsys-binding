namespace EmarsysCommon;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;

public class CompletionListener : Object, EmarsysAndroid.ICompletionListener
{
	private readonly Action<Throwable?> onInvoked;

	public CompletionListener (Action<Throwable?> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void OnCompleted (Throwable? errorCause)
	{
		onInvoked?.Invoke(errorCause);
	}
}

public class EventHandler : Object, EmarsysAndroid.IEventHandler
{
	private readonly Action<Context, string, JSONObject?> onInvoked;

	public EventHandler (Action<Context, string, JSONObject?> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void HandleEvent (Context context, string eventName, JSONObject? payload)
	{
		onInvoked?.Invoke(context, eventName, payload);
	}
}
#endif

public class Utils
{

	#if ANDROID
	public static CompletionListener OnCompleted (Action<Throwable?> onInvoked)
	{
		return new CompletionListener (onInvoked);
	}
	#elif IOS
	public static Action<Foundation.NSError?> OnCompleted (Action<Foundation.NSError?> onInvoked)
	{
		return onInvoked;
	}
	#endif

}
