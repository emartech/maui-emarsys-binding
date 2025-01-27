namespace EmarsysBinding;

public partial class EmarsysPush
{

	private static InternalAPIPush _internal = new InternalAPIPush(new PlatformAPIPush());

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_internal.SetEventHandler(eventHandler);
	}

	public Task<ErrorType?> ClearPushToken()
	{
		return _internal.ClearPushToken();
	}

	public string? GetPushToken()
	{
		return _internal.GetPushToken();
	}

	public void SetSilentMessageEventHandler(EventHandlerAction eventHandler)
	{
		_internal.SetSilentMessageEventHandler(eventHandler);
	}

}
