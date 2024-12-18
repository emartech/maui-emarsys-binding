namespace Sample;

using EmarsysBinding;

public partial class ConfigPage : ContentPage
{

	public ConfigPage()
	{
		InitializeComponent();
	}

	private async void OnSetContactClicked(object sender, EventArgs e)
	{
		int contactFieldId = 100009769;
		string contactFieldValue = "B8mau1nMO8PilvTp6P"; // demoapp@emarsys.com
		// #if ANDROID
		// Java.Lang.Throwable? error =
		// #elif IOS
		// Foundation.NSError? error =
		// #endif
		// 	await Emarsys.SetContact(contactFieldId, contactFieldValue);
		var error = await Emarsys.SetContact(contactFieldId, contactFieldValue);
		Utils.LogResult("SetContact", error);
	}

	private async void OnClearContactClicked(object sender, EventArgs e)
	{
		var error = await Emarsys.ClearContact();
		Utils.LogResult("ClearContact", error);
	}

	private async void OnTrackCustomEventClicked(object sender, EventArgs e)
	{
		string eventName = "testingEventName";
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		var error = await Emarsys.TrackCustomEvent(eventName, eventAttributes);
		Utils.LogResult("TrackCustomEvent", error);
	}

}
