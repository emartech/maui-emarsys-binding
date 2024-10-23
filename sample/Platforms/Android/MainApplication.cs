﻿using Android.App;
using Android.Runtime;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using EmarsysPlugin = EmarsysAndroid.DotnetEmarsys;

namespace MauiSample;

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

	}
	
}
