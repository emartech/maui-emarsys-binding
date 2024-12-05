namespace EmarsysBinding;

#if ANDROID
using EmarsysAndroid;
using EventHandlerAction = Action<Android.Content.Context, string, Org.Json.JSONObject?>;
#elif IOS
using EmarsysiOS;
using EventHandlerAction = Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>>;
#endif

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
