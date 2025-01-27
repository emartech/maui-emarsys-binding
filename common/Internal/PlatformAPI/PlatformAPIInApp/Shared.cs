namespace EmarsysBinding.Internal;

public partial class PlatformAPIInApp : IPlatformAPIInApp
{

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysInApp.SetEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

	public void Pause()
	{
		DotnetEmarsysInApp.Pause();
	}

	public void Resume()
	{
		DotnetEmarsysInApp.Resume();
	}

	public bool IsPaused()
	{
		return DotnetEmarsysInApp.IsPaused;
	}

	public void SetOnEventActionEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysInApp.SetOnEventActionEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

}
