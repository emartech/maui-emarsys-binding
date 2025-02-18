namespace EmarsysBinding.Model;

public class GeofenceTrigger(string id, string type, int loiteringDelay, Dictionary<string, object> action)
{

  public readonly string Id = id;
  public readonly string Type = type;
  public readonly int LoiteringDelay = loiteringDelay;
  public readonly Dictionary<string, object> Action = action;

}
