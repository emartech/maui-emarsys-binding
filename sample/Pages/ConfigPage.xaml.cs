namespace sample;

#if ANDROID
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using Emarsys = EmarsysiOS.DotnetEmarsys;
using UIKit;
using Foundation;
#endif
using EmarsysTask = EmarsysCommon.Task;
using EmarsysUtils = EmarsysCommon.Utils;

public partial class ConfigPage : ContentPage
{

	public ConfigPage()
	{
		InitializeComponent();

		EmarsysResultModeBtn.Text = $"EmarsysResultMode: {Utils.EmarsysResultMode}";
	}

	private async void OnSetContactClicked(object sender, EventArgs e)
	{
		int contactFieldId = 100009769;
		string contactFieldValue = "B8mau1nMO8PilvTp6P"; // demoapp@emarsys.com
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				// #if ANDROID
				// Java.Lang.Throwable? error =
				// #elif IOS
				// Foundation.NSError? error =
				// #endif
				// 	await EmarsysTask.SetContact(contactFieldId, contactFieldValue);
				var error = await EmarsysTask.SetContact(contactFieldId, contactFieldValue);
				Utils.LogResult("SetContact T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.SetContact(contactFieldId, contactFieldValue, EmarsysUtils.CompletionListener((error) =>
				{
					Utils.LogResult("SetContact CL", error);
				}));
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.SetContact(contactFieldId, contactFieldValue);
				Utils.LogResult("SetContact");
				break;
		}
	}

	private async void OnClearContactClicked(object sender, EventArgs e)
	{
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.ClearContact();
				Utils.LogResult("ClearContact T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.ClearContact(EmarsysUtils.CompletionListener((error) =>
				{
					Utils.LogResult("ClearContact CL", error);
				}));
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.ClearContact();
				Utils.LogResult("ClearContact");
				break;
		}
	}

	private async void OnTrackCustomEventClicked(object sender, EventArgs e)
	{
		string eventName = "testingEventName";
		#if ANDROID
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		#elif IOS
		NSDictionary<NSString, NSString> eventAttributes = 
				new NSDictionary<NSString, NSString>(new NSString("param1"), new NSString("value1"));
		#endif
		
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.TrackCustomEvent(eventName, eventAttributes);
				Utils.LogResult("TrackCustomEvent T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.TrackCustomEvent(eventName, eventAttributes, EmarsysUtils.CompletionListener((error) =>
				{
					Utils.LogResult("TrackCustomEvent CL", error);
				}));
				break;
			case Utils.ResultMode.Ignore:
				Emarsys.TrackCustomEvent(eventName, eventAttributes);
				Utils.LogResult("TrackCustomEvent");
				break;
		}
	}

	private void OnEmarsysResultModeClicked(object sender, EventArgs e)
	{
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				Utils.EmarsysResultMode = Utils.ResultMode.CompletionListener;
				break;
			case Utils.ResultMode.CompletionListener:
				Utils.EmarsysResultMode = Utils.ResultMode.Ignore;
				break;
			case Utils.ResultMode.Ignore:
				Utils.EmarsysResultMode = Utils.ResultMode.Task;
				break;
		}
		EmarsysResultModeBtn.Text = $"EmarsysResultMode: {Utils.EmarsysResultMode}";
	}

}
