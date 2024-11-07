﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using EmarsysPlugin = EmarsysAndroid.DotnetEmarsys;
using Org.Json;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel;
using System.Collections.Generic;
using MauiAppApplication = Microsoft.Maui.Controls.Application;

namespace sample;

[Application]
public class MainApplication : MauiApplication, EmarsysPlugin.IEmarsysEventListener
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override void OnCreate()
    {
        base.OnCreate();

        var config = EmarsysPlugin.Config(this, "EMSF3-5F5C2",  "102F6519FC312033", null, true);
        EmarsysPlugin.Setup(config);

        EmarsysPlugin.SetEventListener(this);

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            CreateNotificationChannels();
        }
    }

    public void HandleEvent(Context? context, string? eventName, JSONObject? payload)
    {
        string payloadString = payload?.ToString() ?? "No payload";
        Utils.DisplayAlert("Notification Event", $"Event: {eventName}\nData: {payloadString}");
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
