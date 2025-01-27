namespace EmarsysBinding.Internal;

using Foundation;
using UserNotifications;

public partial class PlatformAPIPush
{

	public void SetDelegate()
	{
		DotnetEmarsysPush.SetDelegate();
	}

	public void SetPushToken(NSData pushToken, OnCompletedAction onCompleted)
	{
		DotnetEmarsysPush.SetPushToken(pushToken, PlatformUtils.CompletionListener(onCompleted));
	}

	public void HandleMessage(NSDictionary userInfo)
	{
		DotnetEmarsysPush.HandleMessage(userInfo);
	}

	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		DotnetEmarsysPush.DidReceiveNotificationRequest(request, contentHandler);
	}

	public void TimeWillExpire()
	{
		DotnetEmarsysPush.TimeWillExpire();
	}

}
