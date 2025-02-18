namespace EmarsysBinding.Internal;

using Foundation;

partial class PlatformUtils
{

	public static Action<NSError?> CompletionListener(OnCompletedAction action)
	{
		return (error) =>
		{
			action(error == null ? null : new Exception(error.Description));
		};
	}

	public static EventHandlerAction EventHandler(EventHandlerAction action)
	{
		return action;
	}

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

	public static object ToDotnetObject(object obj)
	{
		switch(obj)
		{
			case NSArray nsArray:
				return ToDotnetList(nsArray);
			case NSDictionary nsDict:
				return ToDotnetDictionary(nsDict);
			case NSString nsString:
				return nsString.ToString();
			case NSNumber nsNumber:
				return nsNumber.Int32Value;
			default:
				return obj;
		}
	}

	private static List<object> ToDotnetList(NSArray nsArray)
	{
		var list = new List<object>();
		foreach (var item in nsArray)
		{
			list.Add(ToDotnetObject(item));
		}
		return list;
	}

	private static Dictionary<string, object> ToDotnetDictionary(NSDictionary nsDict)
	{
		var dict = new Dictionary<string, object>();
		foreach (var key in nsDict.Keys)
		{
			dict[key.ToString()] = ToDotnetObject(nsDict[key]);
		}
		return dict;
	}

}
