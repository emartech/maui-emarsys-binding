namespace EmarsysBinding.Internal;

public partial class PlatformAPIPush : IPlatformAPIPush
{

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysPush.SetEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

	public void ClearPushToken(OnCompletedAction onCompleted)
	{
		DotnetEmarsysPush.ClearPushToken(PlatformUtils.CompletionListener(onCompleted));
	}

	public string? GetPushToken()
	{
		return DotnetEmarsysPush.PushToken;
	}

	public void SetSilentMessageEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysPush.SetSilentMessageEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

}
