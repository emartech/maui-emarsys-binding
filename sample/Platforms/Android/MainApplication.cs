using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using System.Collections.Generic;
using EmarsysBinding = EmarsysAndroid.DotnetEmarsys;
using EmarsysEventHandler = EmarsysCommon.EventHandler;

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

        var config = EmarsysBinding.Config(this, "EMSF3-5F5C2",  "102F6519FC312033", null, null, true);
        EmarsysBinding.Setup(config);
        EmarsysBinding.Push.SetEventHandler(new EmarsysEventHandler((context, eventName, payload) =>
        {
            string payloadString = payload?.ToString() ?? "No payload";
            Utils.DisplayAlert("Notification Event", $"Event: {eventName}\nData: {payloadString}");
        }));

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
