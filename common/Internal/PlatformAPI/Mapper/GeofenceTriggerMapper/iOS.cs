namespace EmarsysBinding.Internal;

using Foundation;
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

	private static Dictionary<string, object> ToDictionary(NSDictionary<NSString, NSObject> nsDict)
	{
		var dict = new Dictionary<string, object>();
		foreach (var key in nsDict.Keys)
		{
			NSObject obj = nsDict[key];
			if (obj is NSString)
			{
				dict[key] = obj.ToString();
			}
			else if (obj is NSMutableDictionary subDict)
			{
				dict[key] = ToDictionary(subDict);
			}
		}
		return dict;
	}

	private static Dictionary<string, object> ToDictionary(NSMutableDictionary nsDict)
	{
		var dict = new Dictionary<string, object>();
		foreach (var key in nsDict.Keys)
		{
			NSObject obj = nsDict[key.ToString()];
			if (obj is NSString)
			{
				dict[key.ToString()] = obj.ToString();
			}
			else if (obj is NSMutableDictionary subDict)
			{
				dict[key.ToString()] = ToDictionary(subDict);
			}
		}
		return dict;
	}

}
