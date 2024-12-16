#if ANDROID
global using EmarsysAndroid;
global using EventHandlerAction = System.Action<Android.Content.Context, string, Org.Json.JSONObject?>;
global using ErrorType = Java.Lang.Throwable;
#elif IOS
global using EmarsysiOS;
global using EventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>>;
global using ErrorType = Foundation.NSError;
#endif
global using EmarsysBinding.Internal;

namespace EmarsysBinding;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;
#elif IOS
using Foundation;
#endif

class Utils
{

	#if ANDROID
	public static CompletionListener CompletionListener(Action<Throwable?>? action)
	{
		return new CompletionListener(action);
	}
	#elif IOS
	public static Action<NSError?>? CompletionListener(Action<NSError?>? action)
	{
		return action;
	}
	#endif

	#if ANDROID
	public static EventHandler EventHandler(Action<Context, string, JSONObject?> action)
	{
		return new EventHandler(action);
	}
	#elif IOS
	public static Action<NSString, NSDictionary<NSString, NSObject>> EventHandler(Action<NSString, NSDictionary<NSString, NSObject>> action)
	{
		return action;
	}
	#endif

}

#if ANDROID
class CompletionListener : Object, ICompletionListener
{
	private readonly Action<Throwable?>? action;

	public CompletionListener(Action<Throwable?>? action)
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
	private readonly Action<Context, string, JSONObject?> action;

	public EventHandler(Action<Context, string, JSONObject?> action)
	{
		this.action = action;
	}

	public void HandleEvent(Context context, string eventName, JSONObject? payload)
	{
		action?.Invoke(context, eventName, payload);
	}
}
#endif
