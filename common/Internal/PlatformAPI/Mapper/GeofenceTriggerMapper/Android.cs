namespace EmarsysBinding.Internal;

using Java.Lang;
using Org.Json;
using EmarsysBinding.Model;

class GeofenceTriggerMapper
{

	public static List<GeofenceTrigger> Map(IList<EMSGeofenceTrigger> input)
	{
		return input.Select(element =>
			{
				return new GeofenceTrigger(
					id: element.Id,
					type: element.Type,
					loiteringDelay: element.LoiteringDelay,
					action: ToDictionary(element.Action)
				);
			}).ToList();
	}

	private static Dictionary<string, object> ToDictionary(JSONObject obj)
	{
		var dict = new Dictionary<string, object>();
		var keys = obj.Keys();
		while (keys.HasNext)
		{
			string key = keys.Next()!.ToString();
			Object subObj = obj.Get(key);
			if (subObj is String)
			{
				dict[key] = subObj.ToString();
			}
			else if (subObj is JSONObject)
			{
				dict[key] = ToDictionary((JSONObject) subObj);
			}
		}
		return dict;
	}

}
