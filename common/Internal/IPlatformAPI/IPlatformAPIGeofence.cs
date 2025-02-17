namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public interface IPlatformAPIGeofence
{

	public void SetInitialEnterTriggerEnabled(bool initialEnterTriggerEnabled);

	public void Enable(OnCompletedAction onCompleted);

	public void Disable();

	public bool IsEnabled();

	public void SetEventHandler(EventHandlerAction eventHandler);

	public IList<Geofence> GetRegisteredGeofences();

}
