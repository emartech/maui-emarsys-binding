namespace EmarsysBinding.Internal;

using Foundation;
using UserNotifications;

public partial interface IPlatformAPIPush
{

	public void SetDelegate();

	public void SetPushToken(NSData pushToken, OnCompletedAction onCompleted);

	public void HandleMessage(NSDictionary userInfo);

	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler);

	public void TimeWillExpire();

}
