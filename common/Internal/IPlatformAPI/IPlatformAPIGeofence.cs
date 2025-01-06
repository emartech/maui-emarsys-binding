namespace EmarsysBinding.Internal;

public interface IPlatformAPIGeofence
{

	public void SetInitialEnterTriggerEnabled(bool initialEnterTriggerEnabled);

	public void Enable(OnCompletedAction onCompleted);

	public void Disable();

	public bool IsEnabled();

	public void SetEventHandler(EventHandlerAction eventHandler);

	#if ANDROID || IOS
	public IList<EMSGeofence> GetRegisteredGeofences();
	#else
	public string GetRegisteredGeofences();
	#endif

}
