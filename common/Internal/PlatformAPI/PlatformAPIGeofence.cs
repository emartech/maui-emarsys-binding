namespace EmarsysBinding.Internal;

public class PlatformAPIGeofence : IPlatformAPIGeofence
{

	public void SetInitialEnterTriggerEnabled(bool initialEnterTriggerEnabled)
	{
		DotnetEmarsysGeofence.SetInitialEnterTriggerEnabled(initialEnterTriggerEnabled);
	}

	public void Enable(OnCompletedAction onCompleted)
	{
		DotnetEmarsysGeofence.Enable(PlatformUtils.CompletionListener(onCompleted));
	}

	public void Disable()
	{
		DotnetEmarsysGeofence.Disable();
	}

	public bool IsEnabled()
	{
		return DotnetEmarsysGeofence.IsEnabled;
	}

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysGeofence.SetEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

	public IList<EMSGeofence> GetRegisteredGeofences()
	{
		return DotnetEmarsysGeofence.RegisteredGeofences;
	}

}
