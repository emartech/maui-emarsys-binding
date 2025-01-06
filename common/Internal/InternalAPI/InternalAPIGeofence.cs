namespace EmarsysBinding.Internal;

public class InternalAPIGeofence(IPlatformAPIGeofence platform)
{

	private readonly IPlatformAPIGeofence _platform = platform;

	public void SetInitialEnterTriggerEnabled(bool initialEnterTriggerEnabled)
	{
		_platform.SetInitialEnterTriggerEnabled(initialEnterTriggerEnabled);
	}

	public Task<ErrorType?> Enable()
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.Enable(onCompleted);
		});
	}

	public void Disable()
	{
		_platform.Disable();
	}

	public bool IsEnabled()
	{
		return _platform.IsEnabled();
	}

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_platform.SetEventHandler(eventHandler);
	}

	#if ANDROID || IOS
	public IList<EMSGeofence> GetRegisteredGeofences()
	#else
	public string GetRegisteredGeofences()
	#endif
	{
		return _platform.GetRegisteredGeofences();
	}

}
