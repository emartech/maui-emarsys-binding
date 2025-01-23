namespace EmarsysBinding.Internal;

public partial interface IPlatformAPIPush
{

	public void SetDelegate();

	public void SetPushToken(string pushToken, OnCompletedAction onCompleted);

	public void HandleMessage(string message);

	public void DidReceiveNotificationRequest(string request);

	public void TimeWillExpire();

}
