﻿namespace EmarsysBinding.Internal;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;
using OnResultCallbackAction = System.Action<EmarsysAndroid.EMSMessage?, Java.Lang.Throwable?>;
#elif IOS
using Foundation;
using OnResultCallbackAction = System.Action<Foundation.NSArray, Foundation.NSError?>;
#endif

class PlatformUtils
{

	#if ANDROID
	public static CompletionListener CompletionListener(OnCompletedAction action)
	{
		return new CompletionListener(action);
	}
	public static ResultCallback ResultCallback(OnResultCallbackAction action)
	{
		return new ResultCallback(action);
	}
	#elif IOS
	public static OnCompletedAction CompletionListener(OnCompletedAction action)
	{
		return action;
	}
	public static OnResultCallbackAction ResultCallback(OnResultCallbackAction action)
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
		if (dictionary == null)
		{
			return null;
		}
		var keys = dictionary.Keys.Select(key => new NSString(key)).ToArray();
		var values = dictionary.Values.Select(value => new NSString(value)).ToArray();
		return NSDictionary<NSString, NSString>.FromObjectsAndKeys(values, keys);
	}
	#endif

}

#if ANDROID
class CompletionListener(OnCompletedAction action) : Object, ICompletionListener
{
	private readonly OnCompletedAction _action = action;

	public void OnCompleted(Throwable? errorCause)
	{
		_action.Invoke(errorCause);
	}
}

public class ResultCallback : Object, IResultCallback
{
	private readonly OnResultCallbackAction _action;

	public ResultCallback(OnResultCallbackAction action)
	{
		_action = action;
	}

	public void OnResult(EMSMessage messages, Throwable error)
	{
		_action.Invoke(messages, error);
	}
}

class EventHandler(EventHandlerAction action) : Object, IEventHandler
{
	private readonly EventHandlerAction _action = action;

	public void HandleEvent(Context context, string eventName, JSONObject? payload)
	{
		_action.Invoke(context, eventName, payload);
	}
}
#endif
