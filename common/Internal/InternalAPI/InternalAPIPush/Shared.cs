namespace EmarsysBinding.Internal;

public partial class InternalAPIPush(IPlatformAPIPush platform)
{

	private readonly IPlatformAPIPush _platform = platform;

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_platform.SetEventHandler(eventHandler);
	}

	public Task<ErrorType?> ClearPushToken()
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.ClearPushToken(onCompleted);
		});
	}

	public string? GetPushToken()
	{
		return _platform.GetPushToken();
	}

	public void SetSilentMessageEventHandler(EventHandlerAction eventHandler)
	{
		_platform.SetSilentMessageEventHandler(eventHandler);
	}

}
