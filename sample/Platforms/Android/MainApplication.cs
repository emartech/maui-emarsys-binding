﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Org.Json;

namespace Sample;

using EmarsysBinding;

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

        var config = Emarsys.Config.Build(this, "EMS12-04EC1", "1DF86BF95CBE8F19", null, null, true);
        Emarsys.Setup(config);

        Action<Context, string, JSONObject?> eventHandler = (context, eventName, payload) =>
        {
            string payloadString = payload?.ToString() ?? "No payload";
            Utils.DisplayAlert("Handle event", $"Event: {eventName}\nPayload: {payloadString}");
        };
        Emarsys.Push.SetEventHandler(eventHandler);
        Emarsys.Push.SetSilentMessageEventHandler(eventHandler);
        Emarsys.InApp.SetEventHandler(eventHandler);
        Emarsys.InApp.SetOnEventActionEventHandler(eventHandler);
        Emarsys.Geofence.SetEventHandler(eventHandler);

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
