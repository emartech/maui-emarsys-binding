namespace EmarsysBinding.Internal;

using Java.Lang;
using Java.Util;
using Android.Content;
using Android.Runtime;
using Org.Json;

partial class PlatformUtils
{

	public static CompletionListener CompletionListener(OnCompletedAction action)
	{
		return new CompletionListener(action);
	}

	public static EventHandler EventHandler(EventHandlerAction action)
	{
		return new EventHandler(action);
	}

	public static Dictionary<string, string>? ToNativeDictionary(Dictionary<string, string>? dictionary)
	{
		return dictionary;
	}

	public static object ToDotnetObject(object obj)
	{
		switch (obj)
		{
			case JavaList jList:
				return ToDotnetList(jList);
			case JavaDictionary jDictionary:
				return ToDotnetDictionary(jDictionary);
			case String jString:
				return jString.ToString();
			case Integer jInteger:
				return jInteger.IntValue();
			case Boolean jBoolean:
				return jBoolean.BooleanValue();
			case Double jDouble:
				return jDouble.DoubleValue();
			default:
				return obj;
		}
	}

	private static List<object> ToDotnetList(JavaList javaList)
	{
		var list = new List<object>();
		foreach (var item in javaList)
		{
			list.Add(ToDotnetObject(item));
		}
		return list;
	}

	private static Dictionary<string, object> ToDotnetDictionary(JavaDictionary javaDictionary)
	{
		var dict = new Dictionary<string, object>();
		foreach (var key in javaDictionary.Keys)
		{
			var item = javaDictionary[key];
			if (item != null) {
				dict[key.ToString()!] = ToDotnetObject(item);
			}
		}
		return dict;
	}

}

class CompletionListener(OnCompletedAction action) : Object, ICompletionListener
{

	private readonly OnCompletedAction _action = action;

	public void OnCompleted(Throwable? errorCause)
	{
		_action.Invoke(errorCause == null ? null : new Exception(errorCause.Message));
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
