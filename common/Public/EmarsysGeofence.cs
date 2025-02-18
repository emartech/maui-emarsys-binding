namespace EmarsysBinding;

using EmarsysBinding.Model;

public class EmarsysGeofence
{

	internal EmarsysGeofence() {}

	private static InternalAPIGeofence _internal = new InternalAPIGeofence(new PlatformAPIGeofence());

	public void SetInitialEnterTriggerEnabled(bool initialEnterTriggerEnabled)
	{
		_internal.SetInitialEnterTriggerEnabled(initialEnterTriggerEnabled);
	}

	public Task<ErrorType?> Enable()
	{
		return _internal.Enable();
	}

	public void Disable()
	{
		_internal.Disable();
	}

	public bool IsEnabled()
	{
		return _internal.IsEnabled();
	}

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_internal.SetEventHandler(eventHandler);
	}

	public IList<Geofence> GetRegisteredGeofences()
	{
		return _internal.GetRegisteredGeofences();
	}

}
