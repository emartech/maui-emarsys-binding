namespace Sample;

class Utils
{

	public static void DisplayAlert(string title, string message = "", string cancel = "OK")
	{
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			Page? page = Microsoft.Maui.Controls.Application.Current?.MainPage;
			if (page != null)
			{
				await page.DisplayAlert(title, message, cancel);
			}
		});
	}

	public static void LogResult(string method, Exception? error = null, string? message = null)
	{
		if (error == null)
		{
			if (message == null)
			{
				Console.WriteLine($"{method} done");
				DisplayAlert($"{method} done");
			}
			else
			{
				Console.WriteLine($"{method} done: {message}");
				DisplayAlert($"{method} done", message);
			}
		}
		else
		{
			Console.WriteLine($"{method} fail: {error}");
			DisplayAlert($"{method} fail", error.Message);
		}
	}

}
