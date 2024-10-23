using Android.App;
using Firebase.Messaging;

[Service(Exported = true)]
[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
public class MyFirebaseMessagingService : FirebaseMessagingService
{
    public MyFirebaseMessagingService() { }

    public override void OnNewToken(string token)
    {   
        
        base.OnNewToken(token);
        Console.WriteLine("NEW_TOKEN", token);
        Console.WriteLine(token);
        Console.WriteLine("--------------");
    }

    public override void OnMessageReceived(RemoteMessage message)
    {
        base.OnMessageReceived(message);
        Console.WriteLine("OnMessageReceived", message);
    }
}