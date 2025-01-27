namespace EmarsysBinding.Internal;

#if !ANDROID && !IOS
using EMSGeofence = string;
#endif

public interface IPlatformAPIGeofence
{

	public void SetInitialEnterTriggerEnabled(bool initialEnterTriggerEnabled);

	public void Enable(OnCompletedAction onCompleted);

	public void Disable();

	public bool IsEnabled();

	public void SetEventHandler(EventHandlerAction eventHandler);

	public IList<EMSGeofence> GetRegisteredGeofences();

}
