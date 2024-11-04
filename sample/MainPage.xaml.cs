namespace sample;

#if IOS || MACCATALYST
using Emarsys = EmarsysiOS.DotnetEmarsys;
#elif ANDROID
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID)
using Emarsys = System.Object;
#endif

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnSetContactClicked(object sender, EventArgs e)
	{
		Emarsys.SetContact(3, "eduardo.zatoni@emarsys.com");
		Console.WriteLine("Set contact done!");
	}

	private void OnClearContactClicked(object sender, EventArgs e)
	{
		Emarsys.ClearContact();
		Console.WriteLine("Clear contact done!");
	}
}
