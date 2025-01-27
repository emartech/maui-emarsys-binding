namespace EmarsysBinding.Internal;

public partial class InternalAPIPush
{

	public void SetDelegate()
	{
		_platform.SetDelegate();
	}

	public Task<ErrorType?> SetPushToken(string pushToken)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.SetPushToken(pushToken, onCompleted);
		});
	}

	public void HandleMessage(string message)
	{
		_platform.HandleMessage(message);
	}

	public void DidReceiveNotificationRequest(string request)
	{
		_platform.DidReceiveNotificationRequest(request);
	}

	public void TimeWillExpire()
	{
		_platform.TimeWillExpire();
	}

}
