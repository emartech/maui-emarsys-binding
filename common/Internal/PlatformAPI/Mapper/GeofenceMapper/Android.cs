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
					lat: element.Lat.DoubleValue(),
					lon: element.Lon.DoubleValue(),
					radius: element.Radius.IntValue(),
					waitInterval: element.WaitInterval?.DoubleValue() ?? 0,
					triggers: GeofenceTriggerMapper.Map(element.Triggers)
				);
			}).ToList();
	}

}
