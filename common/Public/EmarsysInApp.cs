namespace EmarsysBinding;

public class EmarsysInApp
{

	internal EmarsysInApp() {}

	private static InternalAPIInApp _internal = new InternalAPIInApp(new PlatformAPIInApp());

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_internal.SetEventHandler(eventHandler);
	}

	public void Pause()
	{
		_internal.Pause();
	}

	public void Resume()
	{
		_internal.Resume();
	}

	public bool IsPaused()
	{
		return _internal.IsPaused();
	}

	public void SetOnEventActionEventHandler(EventHandlerAction eventHandler)
	{
		_internal.SetOnEventActionEventHandler(eventHandler);
	}

}
