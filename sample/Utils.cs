namespace sample;

class Utils
{

	public static void DisplayAlert(string title, string message, string cancel)
	{
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(title, message, cancel);
		});
	}

}
