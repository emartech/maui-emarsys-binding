using Android.App;
using Firebase.Messaging;
using EmarsysPlugin = EmarsysAndroid.DotnetEmarsys;

[Service(Exported = true)]
// TODO: use EmarsysFirebaseMessagingService
// [Service(Exported = true, Name = "com.emarsys.service.EmarsysFirebaseMessagingService")]
[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
public class MyFirebaseMessagingService : FirebaseMessagingService
{
    public MyFirebaseMessagingService() { }

    public override void OnNewToken(string token)
    {
        base.OnNewToken(token);
        EmarsysPlugin.SetPushToken(token);
    }

    public override void OnMessageReceived(RemoteMessage message)
    {
        base.OnMessageReceived(message);
        EmarsysPlugin.HandleMessage(this, message);
    }
}