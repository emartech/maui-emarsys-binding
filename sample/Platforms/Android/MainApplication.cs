using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Org.Json;
using EmarsysB = EmarsysBinding.Emarsys; // Emarsys type conflicts with native SDK, use it with alias e.g. EmarsysB(inding)

namespace Sample;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override void OnCreate()
    {
        base.OnCreate();

        var config = EmarsysB.Config(this, "EMS12-04EC1", "1DF86BF95CBE8F19", null, null, true);
        EmarsysB.Setup(config);

        Action<Context, string, JSONObject?> eventHandler = (context, eventName, payload) =>
        {
            string payloadString = payload?.ToString() ?? "No payload";
            Utils.DisplayAlert("Handle event", $"Event: {eventName}\nPayload: {payloadString}");
        };
        EmarsysB.Push.SetEventHandler(eventHandler);
        EmarsysB.InApp.SetEventHandler(eventHandler);
        EmarsysB.InApp.SetOnEventActionEventHandler(eventHandler);

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            CreateNotificationChannels();
        }
    }

    private void CreateNotificationChannels()
    {
        #pragma warning disable CA1416
        var channel1 = new NotificationChannel("ems_sample_news", "News", NotificationImportance.High)
        {
            Description = "News"
        };

        var channel2 = new NotificationChannel("ems_sample_messages", "Messages", NotificationImportance.High)
        {
            Description = "Messages"
        };

        if (GetSystemService(NotificationService) is NotificationManager manager)
        {
            manager.CreateNotificationChannel(channel1);
            manager.CreateNotificationChannel(channel2);
        }
        #pragma warning restore CA1416
    }
}
