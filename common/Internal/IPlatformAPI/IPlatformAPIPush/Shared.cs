namespace EmarsysBinding.Internal;

public partial interface IPlatformAPIPush
{

	public void SetEventHandler(EventHandlerAction eventHandler);

	public void ClearPushToken(OnCompletedAction onCompleted);

	public string? GetPushToken();

	public void SetSilentMessageEventHandler(EventHandlerAction eventHandler);

}
