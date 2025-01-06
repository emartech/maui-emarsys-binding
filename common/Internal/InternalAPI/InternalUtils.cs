namespace EmarsysBinding.Internal;

using Foundation;

class InternalUtils
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
}

public static class NSDictionaryExtensions
{
	public static Dictionary<string, object> ToDictionary(this NSDictionary nsDict)
	{
		var dict = new Dictionary<string, object>();
		foreach (var key in nsDict.Keys)
		{
			var keyString = key.ToString();
			var value = nsDict[key];

			// if (keyString == "properties" && value is NSDictionary propDict)
			// {
			// 	dict[keyString] = propDict.ToDictionaryString();
			// 	continue;
			// }

			if (value is NSDictionary nestedDict)
			{
				dict[keyString] = nestedDict.ToDictionary();
			}
			else if (value is NSArray nestedArray)
			{
				dict[keyString] = nestedArray.ToList<object>();
			}
			else if (value is NSString nsString)
			{
				dict[keyString] = nsString.ToString();
			}
			else if (value is NSNumber nsNumber)
			{
				dict[keyString] = nsNumber.Int32Value;
			}
			else
			{
				dict[keyString] = value;
			}
		}
		return dict;
	}

	public static List<object> ToList(this NSArray nsArray)
	{
		var list = new List<object>();
		for (nuint i = 0; i < nsArray.Count; i++)
		{
			list.Add(nsArray.GetItem<NSObject>(i));
		}
		return list;
	}

	public static Dictionary<string, string> ToDictionaryString(this NSDictionary nsDict)
	{
		var dict = new Dictionary<string, string>();
		foreach (var key in nsDict.Keys)
		{
			if (key is NSString nsKey && nsDict[key] is NSString nsValue)
			{
				dict[nsKey.ToString()] = nsValue.ToString();
			}
		}
		return dict;
	}
}