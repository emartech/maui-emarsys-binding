namespace EmarsysBinding;

public class InApp
{

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsys.InApp.SetEventHandler(Utils.EventHandler(eventHandler));
	}

	public void Pause()
	{
		DotnetEmarsys.InApp.Pause();
	}

	public void Resume()
	{
		DotnetEmarsys.InApp.Resume();
	}

	public bool IsPaused()
	{
		return DotnetEmarsys.InApp.IsPaused;
	}

	public void SetOnEventActionEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsys.InApp.SetOnEventActionEventHandler(Utils.EventHandler(eventHandler));
	}

}
