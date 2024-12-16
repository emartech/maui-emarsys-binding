namespace Sample;

using EmarsysBinding;

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
		
		switch (Utils.EmarsysResultMode)
		{
			case Utils.ResultMode.Task:
				var error = await EmarsysTask.TrackCustomEvent(eventName, eventAttributes);
				Utils.LogResult("TrackCustomEvent T", error);
				break;
			case Utils.ResultMode.CompletionListener:
				Emarsys.TrackCustomEvent(eventName, eventAttributes, (error) =>
				{
					Utils.LogResult("TrackCustomEvent CL", error);
				});
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
