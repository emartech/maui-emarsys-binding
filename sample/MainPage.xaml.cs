namespace sample;

using EmarsysTask = EmarsysCommon.Task;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		EmarsysResultModeBtn.Text = $"EmarsysResultMode: {Utils.EmarsysResultMode}";
	}

	private async void OnSetContactClicked(object sender, EventArgs e)
	{
		// #if ANDROID
		// Java.Lang.Throwable? error =
		// #elif IOS
		// Foundation.NSError? error =
		// #endif
		// 	await EmarsysTask.SetContact(3, "eduardo.zatoni@emarsys.com");
		var error = await EmarsysTask.SetContact(3, "eduardo.zatoni@emarsys.com");
		Utils.LogResult("SetContact", error);
	}

	private async void OnClearContactClicked(object sender, EventArgs e)
	{
		var error = await EmarsysTask.ClearContact();
		Utils.LogResult("ClearContact", error);
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
