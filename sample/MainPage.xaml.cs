namespace sample;

using EmarsysTask = EmarsysCommon.Task;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
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
}
