namespace Sample;

using EmarsysBinding;

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

	private void OnPauseClicked(object sender, EventArgs e)
	{
		Emarsys.InApp.Pause();
		Utils.LogResult("Pause");
	}

	private void OnResumeClicked(object sender, EventArgs e)
	{
		Emarsys.InApp.Resume();
		Utils.LogResult("Resume");
	}

	private void OnGetIsPausedClicked(object sender, EventArgs e)
	{
		var isPaused = Emarsys.InApp.IsPaused();
		Utils.LogResult("IsPaused", null, $"{isPaused}");
	}

	private void OnLoadInlineInAppClicked(object sender, EventArgs e)
	{
		inlineInAppView.LoadInApp("view-id");
	}

	private async void OnFetchInboxMessagesClicked(object sender, EventArgs e)
	{
		var messages = await Emarsys.Inbox.FetchMessages();
		Utils.LogResult("FetchMessages", null, $"{messages}");
	}

	private async void OnAddTagClicked(object sender, EventArgs e)
	{
		var tag = "seen";
		var messageId = "123456";
		var error = await Emarsys.Inbox.AddTag(tag, messageId);
		Utils.LogResult("AddTag", error);
	}

	private async void OnRemoveTagClicked(object sender, EventArgs e)
	{
		var tag = "seen";
		var messageId = "123456";
		var error = await Emarsys.Inbox.RemoveTag(tag, messageId);
		Utils.LogResult("RemoveTag");
	}
}
