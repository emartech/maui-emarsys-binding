namespace EmarsysBinding.Internal;

using Foundation;
using UserNotifications;

public partial class InternalAPIPush
{

	public void SetDelegate()
	{
		_platform.SetDelegate();
	}

	public Task<ErrorType?> SetPushToken(NSData pushToken)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.SetPushToken(pushToken, onCompleted);
		});
	}

	public void HandleMessage(NSDictionary userInfo)
	{
		_platform.HandleMessage(userInfo);
	}

	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		_platform.DidReceiveNotificationRequest(request, contentHandler);
	}

	public void TimeWillExpire()
	{
		_platform.TimeWillExpire();
	}

}
