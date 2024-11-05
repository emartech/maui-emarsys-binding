namespace sample;

#if IOS
using Emarsys = EmarsysiOS.DotnetEmarsys;
using EmarsysUtils = EmarsysiOS.Utils;
#elif ANDROID
using Emarsys = EmarsysAndroid.DotnetEmarsys;
using EmarsysUtils = EmarsysAndroid.Utils;
#endif

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnSetContactClicked(object sender, EventArgs e)
	{
		Emarsys.SetContact(3, "eduardo.zatoni@emarsys.com", EmarsysUtils.Completion((error) =>
		{
			if (error == null)
			{
				Console.WriteLine("Set contact done!");
				Utils.DisplayAlert("Set contact done!", null, "OK");
			}
			else
			{
				Console.WriteLine($"Set contact failed: {error}");
				Utils.DisplayAlert("Set contact failed", $"{error}", "OK");
			}
		}));
	}

	private void OnClearContactClicked(object sender, EventArgs e)
	{
		Emarsys.ClearContact();
		Console.WriteLine("Clear contact done!");
	}
}
