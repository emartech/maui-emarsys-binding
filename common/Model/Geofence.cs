namespace EmarsysBinding.Model;

public class Geofence(string id, double lat, double lon, int radius, double waitInterval, List<GeofenceTrigger> triggers)
{

  public readonly string Id = id;
  public readonly double Lat = lat;
  public readonly double Lon = lon;
  public readonly int Radius = radius;
  public readonly double WaitInterval = waitInterval;
  public readonly List<GeofenceTrigger> Triggers = triggers;

}
