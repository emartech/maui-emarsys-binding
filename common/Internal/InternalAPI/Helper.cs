namespace EmarsysBinding.Internal;

using Foundation;

class Helper
{
	public static Dictionary<string, object> ConvertNSDictionaryToDictionary(NSDictionary nsDict)
	{
		var dict = new Dictionary<string, object>();
		foreach (var key in nsDict.Keys)
		{
			var keyString = key.ToString();
			var value = nsDict[key];

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

  public static Dictionary<string, string> ConvertToStringDictionary(Dictionary<NSObject, NSObject> dictionary)
  {
    var stringDictionary = new Dictionary<string, string>();

    foreach (var kvp in dictionary)
    {
      var key = kvp.Key.ToString();
      var value = kvp.Value.ToString();

      stringDictionary[key] = value;
    }

    return stringDictionary;
  }

  public static List<T> ConvertNSArrayToList<T>(NSArray nsArray)
	{
		var list = new List<T>();

		for (nuint i = 0; i < nsArray.Count; i++)
		{
			var item = nsArray.GetItem<NSObject>(i);

			if (typeof(T) == typeof(Dictionary<string, object>))
			{
				if (item is NSDictionary nsDict)
				{
					var dict = ConvertNSDictionaryToDictionary(nsDict);
					list.Add((T)(object)dict);
				}
			}
			else if (typeof(T) == typeof(string))
			{
				if (item is NSString nsString)
				{
					list.Add((T)(object)nsString.ToString());
				}
			}
			else if (typeof(T) == typeof(int))
			{
				if (item is NSNumber nsNumber)
				{
					list.Add((T)(object)nsNumber.Int32Value);
				}
			}
			else
			{
				list.Add((T)(object)item);
			}
		}

		return list;
	}
}