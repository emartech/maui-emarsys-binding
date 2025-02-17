namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

class GeofenceMapper
{

	public static List<Geofence> Map(IList<EMSGeofence> input)
	{
		return input.Select(element =>
			{
				return new Geofence(
					id: element.Id,
					lat: element.Lat,
					lon: element.Lon,
					radius: element.Radius,
					waitInterval: element.WaitInterval,
					triggers: GeofenceTriggerMapper.Map(element.Triggers)
				);
			}).ToList();
	}

}
