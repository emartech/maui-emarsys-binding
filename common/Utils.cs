namespace EmarsysBinding;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;
using EmarsysAndroid;
#elif IOS
using Foundation;
#endif

class Utils
{

	#if ANDROID
	public static CompletionListener CompletionListener(Action<Throwable?>? onInvoked)
	{
		return new CompletionListener(onInvoked);
	}
	#elif IOS
	public static Action<NSError?>? CompletionListener(Action<NSError?>? onInvoked)
	{
		return onInvoked;
	}
	#endif

	#if ANDROID
	public static EventHandler EventHandler(Action<Context, string, JSONObject?> onInvoked)
	{
		return new EventHandler(onInvoked);
	}
	#elif IOS
	public static Action<NSString, NSDictionary<NSString, NSObject>> EventHandler(Action<NSString, NSDictionary<NSString, NSObject>> onInvoked)
	{
		return onInvoked;
	}
	#endif

	#if IOS
	public static NSDictionary<NSString, NSString> ToNSDictionary(Dictionary<string, string> dictionary)
	{
    if (dictionary == null) {
        return null;
		}

    var keys = dictionary.Keys.Select(key => new NSString(key)).ToArray();
    var values = dictionary.Values.Select(value => new NSString(value)).ToArray();
    return NSDictionary<NSString, NSString>.FromObjectsAndKeys(values, keys);
	}
	#endif
}

#if ANDROID
class CompletionListener : Object, ICompletionListener
{
	private readonly Action<Throwable?>? onInvoked;

	public CompletionListener(Action<Throwable?>? onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void OnCompleted(Throwable? errorCause)
	{
		onInvoked?.Invoke(errorCause);
	}
}

class EventHandler : Object, IEventHandler
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
