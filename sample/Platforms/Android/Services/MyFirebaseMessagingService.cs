// It is recommended to use EmarsysFirebaseMessagingService to automatcially handle push.
// Please register the service in your manifest.
// Reference to sample: https://github.com/emartech/maui-emarsys-binding/blob/main/sample/Platforms/Android/AndroidManifest.xml#L4

// If it is needed, this is a sample FirebaseMessagingService subclass that demostrates
// how push token and received push message should be handled by Emarsys SDK in a custom implementation.
// Reference to Native SDK sample: https://github.com/emartech/android-emarsys-sdk?tab=readme-ov-file#java

// using Android.App;
// using Firebase.Messaging;
// using EmarsysBinding = EmarsysAndroid.DotnetEmarsys;

// [Service(Exported = true)]
// [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
// public class MyFirebaseMessagingService : FirebaseMessagingService
// {

//     public MyFirebaseMessagingService() { }

//     public override void OnNewToken(string token)
//     {
//         base.OnNewToken(token);
        
//         EmarsysBinding.Push.PushToken = token;
//     }

//     public override void OnMessageReceived(RemoteMessage message)
//     {
//         base.OnMessageReceived(message);

//         bool handledByEmarsysSDK = (bool) EmarsysBinding.Push.HandleMessage(this, message);
//         if (!handledByEmarsysSDK) {
//           // handle your message here
//         }
//     }

// }
