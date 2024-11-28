namespace EmarsysBinding;

#if ANDROID
using Java.Lang;
using Android.Content;
using Org.Json;
using Firebase.Messaging;
using EmarsysAndroid;
#elif IOS
using Foundation;
using UserNotifications;
using EmarsysiOS;
#endif

public class Push
{

	#if ANDROID
	public void SetEventHandler(Action<Context, string, JSONObject?> handleEvent)
	#elif IOS
	public void SetEventHandler(Action<NSString, NSDictionary<NSString, NSObject>> handleEvent)
	#endif
	{
		DotnetEmarsys.Push.SetEventHandler(Utils.EventHandler(handleEvent));
	}

	#if ANDROID
	public void SetPushToken(string pushToken, Action<Throwable?>? onCompleted = null)
	#elif IOS
	public void SetPushToken(NSData pushToken, Action<NSError?>? onCompleted = null)
	#endif
	{
		DotnetEmarsys.Push.SetPushToken(pushToken, Utils.CompletionListener(onCompleted));
	}

	#if ANDROID
	public void ClearPushToken(Action<Throwable?>? onCompleted = null)
	#elif IOS
	public void ClearPushToken(Action<NSError?>? onCompleted = null)
	#endif
	{
		DotnetEmarsys.Push.ClearPushToken(Utils.CompletionListener(onCompleted));
	}

	public string? GetPushToken()
	{
		return DotnetEmarsys.Push.PushToken;
	}

	#if ANDROID
	public bool HandleMessage(Context context, RemoteMessage message)
	{
		return DotnetEmarsys.Push.HandleMessage(context, message);
	}
	#elif IOS
	public void HandleMessage(NSDictionary userInfo)
	{
		DotnetEmarsys.Push.HandleMessage(userInfo);
	}
	#endif

	#if IOS
	public void SetDelegate()
	{
		DotnetEmarsys.Push.SetDelegate();
	}

	public void DidReceiveNotificationRequest(UNNotificationRequest request, Action<UNNotificationContent> contentHandler)
	{
		DotnetEmarsys.Push.DidReceiveNotificationRequest(request, contentHandler);
	}

	public void TimeWillExpire()
	{
		DotnetEmarsys.Push.TimeWillExpire();
	}
	#endif

}
