using Android.App;
using Android.Runtime;
using Android.OS;
using EmarsysPlugin = EmarsysAndroid.DotnetEmarsys;

namespace sample;

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

        EmarsysPlugin.Setup(this, "EMSF3-5F5C2");

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
            Description = "This is Channel 1"
        };

        var channel2 = new NotificationChannel("ems_sample_messages", "Messages", NotificationImportance.High)
        {
            Description = "This is Channel 2"
        };

        if (GetSystemService(NotificationService) is NotificationManager manager)
        {
            manager.CreateNotificationChannel(channel1);
            manager.CreateNotificationChannel(channel2);
        }
        #pragma warning restore CA1416
    }
}