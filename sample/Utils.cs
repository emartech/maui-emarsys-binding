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

	#if ANDROID
	public static void LogResult(string method, Java.Lang.Throwable? error = null, string? message = null)
	#elif IOS
	public static void LogResult(string method, Foundation.NSError? error = null, string? message = null)
	#endif
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
			#if ANDROID
			Console.WriteLine($"{method} fail: {error.Message}");
			DisplayAlert($"{method} fail", error.Message ?? "");
			#elif IOS
			Console.WriteLine($"{method} fail: {error.Description}");
			DisplayAlert($"{method} fail", error.Description);
			#endif
		}
	}

}
