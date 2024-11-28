namespace EmarsysCommon;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;
#elif IOS
using Foundation;
#endif

public class Utils
{

	#if ANDROID
	public static CompletionListener CompletionListener(Action<Throwable?> onInvoked)
	{
		return new CompletionListener(onInvoked);
	}
	#elif IOS
	public static Action<NSError?> CompletionListener(Action<NSError?> onInvoked)
	{
		return onInvoked;
	}
	#endif

}

#if ANDROID
public class CompletionListener : Object, EmarsysAndroid.ICompletionListener
{
	private readonly Action<Throwable?> onInvoked;

	public CompletionListener(Action<Throwable?> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void OnCompleted(Throwable? errorCause)
	{
		onInvoked?.Invoke(errorCause);
	}
}

public class EventHandler : Object, EmarsysAndroid.IEventHandler
{
	private readonly Action<Context, string, JSONObject?> onInvoked;

	public EventHandler(Action<Context, string, JSONObject?> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void HandleEvent(Context context, string eventName, JSONObject? payload)
	{
		onInvoked?.Invoke(context, eventName, payload);
	}
}
#endif
