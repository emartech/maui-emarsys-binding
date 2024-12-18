#if ANDROID
global using EmarsysAndroid;
global using OnCompletedAction = System.Action<Java.Lang.Throwable?>;
global using EventHandlerAction = System.Action<Android.Content.Context, string, Org.Json.JSONObject?>;
global using ErrorType = Java.Lang.Throwable;
#elif IOS
global using EmarsysiOS;
global using OnCompletedAction = System.Action<Foundation.NSError?>;
global using EventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>>;
global using ErrorType = Foundation.NSError;
#else
global using OnCompletedAction = System.Action<string>;
global using EventHandlerAction = System.Action<string>;
global using ErrorType = string;
#endif

namespace EmarsysBinding.Internal;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;
#elif IOS
using Foundation;
#endif

class Utils
{

	public static Task<ErrorType?> Task(Action<OnCompletedAction> callback)
	{
		var cs = new TaskCompletionSource<ErrorType?>();
		callback((error) =>
		{
			cs.SetResult(error);
		});
		return cs.Task;
	}

	#if ANDROID
	public static CompletionListener CompletionListener(OnCompletedAction? action)
	{
		return new CompletionListener(action);
	}
	#elif IOS
	public static OnCompletedAction? CompletionListener(OnCompletedAction? action)
	{
		return action;
	}
	#endif

	#if ANDROID
	public static EventHandler EventHandler(EventHandlerAction action)
	{
		return new EventHandler(action);
	}
	#elif IOS
	public static EventHandlerAction EventHandler(EventHandlerAction action)
	{
		return action;
	}
	#endif

	#if ANDROID
	public static Dictionary<string, string>? ToNativeDictionary(Dictionary<string, string>? dictionary)
	{
		return dictionary;
	}
	#elif IOS
	public static NSDictionary<NSString, NSString>? ToNativeDictionary(Dictionary<string, string>? dictionary)
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
	private readonly OnCompletedAction? action;

	public CompletionListener(OnCompletedAction? action)
	{
		this.action = action;
	}

	public void OnCompleted(Throwable? errorCause)
	{
		action?.Invoke(errorCause);
	}
}

class EventHandler : Object, IEventHandler
{
	private readonly EventHandlerAction action;

	public EventHandler(EventHandlerAction action)
	{
		this.action = action;
	}

	public void HandleEvent(Context context, string eventName, JSONObject? payload)
	{
		action?.Invoke(context, eventName, payload);
	}
}
#endif
