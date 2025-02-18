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
					action: (Dictionary<string, object>) PlatformUtils.ToDotnetObject(element.Action)
				);
			}).ToList();
	}

}
