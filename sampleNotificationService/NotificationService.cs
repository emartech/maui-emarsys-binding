using Foundation;
using ObjCRuntime;
using UserNotifications;
using Emarsys = EmarsysiOS.DotnetEmarsys;

namespace sampleNotificationService;

[Register("NotificationService")]
public class NotificationService : UNNotificationServiceExtension
{

	protected NotificationService (IntPtr handle) : base (handle)
	{
		// Note: this .ctor should not contain any initialization logic.
	}

	public override void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		Emarsys.Push.DidReceiveNotificationRequest(request, contentHandler);
	}

	public override void TimeWillExpire()
	{
		Emarsys.Push.TimeWillExpire();
	}

}
