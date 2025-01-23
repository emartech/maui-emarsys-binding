namespace EmarsysBinding;

using Foundation;
using UserNotifications;

public partial class EmarsysPush
{

	public void SetDelegate()
	{
		_internal.SetDelegate();
	}

	public Task<ErrorType?> SetPushToken(NSData pushToken)
	{
		return _internal.SetPushToken(pushToken);
	}

	public void HandleMessage(NSDictionary userInfo)
	{
		_internal.HandleMessage(userInfo);
	}

	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		_internal.DidReceiveNotificationRequest(request, contentHandler);
	}

	public void TimeWillExpire()
	{
		_internal.TimeWillExpire();
	}

}
