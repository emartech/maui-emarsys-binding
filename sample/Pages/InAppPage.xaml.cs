namespace Sample;

public partial class InAppPage : ContentPage
{

	public InAppPage()
	{
		InitializeComponent();

		inlineInAppView.SetEventHandler((eventName, payload) =>
		{
			string payloadString = payload?.ToString() ?? "No payload";
			Utils.DisplayAlert("InlineInApp Event", $"Event: {eventName}\nData: {payloadString}");
		});
		inlineInAppView.SetCompletionListener((error) =>
		{
			if (error == null)
			{
				inlineInAppView.HeightRequest = 125;
			}
			else
			{
				Utils.LogResult("InlineInApp", error);
			}
		});
		inlineInAppView.SetCloseListener(() =>
		{
			inlineInAppView.HeightRequest = 0;
		});
	}

	private void OnLoadInlineInAppClicked(object sender, EventArgs e)
	{
		inlineInAppView.LoadInApp("view-id");
	}

}
