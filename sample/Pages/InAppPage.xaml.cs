namespace Sample;

using EmarsysBinding;
using EmarsysBinding.Model;

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
		try
    {
			var messages = await Emarsys.Inbox.FetchMessages();
			LogInboxMessages(messages);
    }
    catch (Exception ex)
    {
			Utils.LogResult("FetchMessages Error", null, ex.Message);
			Console.WriteLine(ex.StackTrace);
    }
	}

	private async void OnAddTagClicked(object sender, EventArgs e)
	{
		var tag = "seen";
		var messageId = "15831089898";
		var error = await Emarsys.Inbox.AddTag(tag, messageId);
		Utils.LogResult("AddTag", error);
	}

	private async void OnRemoveTagClicked(object sender, EventArgs e)
	{
		var tag = "seen";
		var messageId = "15831089898";
		var error = await Emarsys.Inbox.RemoveTag(tag, messageId);
		Utils.LogResult("RemoveTag");
	}

	private void LogInboxMessages(List<Message>? messages)
	{
		if (messages == null || messages.Count == 0)
		{
			Utils.LogResult("FetchMessages", null, "No messages found.");
		}
		else
		{
			Utils.LogResult("FetchMessages", null, $"{messages}");
			foreach (var message in messages)
			{
				Console.WriteLine($"Id: {message.Id}");
				Console.WriteLine($"CampaignId: {message.CampaignId}");
				Console.WriteLine($"CollapseId: {message.CollapseId}");
				Console.WriteLine($"Title: {message.Title}");
				Console.WriteLine($"Body: {message.Body}");
				Console.WriteLine($"ImageUrl: {message.ImageUrl}");
				Console.WriteLine($"ReceivedAt: {message.ReceivedAt}");
				Console.WriteLine($"UpdatedAt: {message.UpdatedAt}");
				Console.WriteLine($"ExpiresAt: {message.ExpiresAt}");
				if (message.Properties != null)
				{
					foreach (var item in message.Properties)
					{
						Console.WriteLine($"Properties item: {item.Key} - {item.Value}");
					}
				} else {
						Console.WriteLine("No properties found.");
				}

				if (message.Tags != null)
				{
					foreach (var tag in message.Tags)
					{
						Console.WriteLine($"Tag: {tag}");
					}
				} else {
					Console.WriteLine("No tags found.");
				}

				if (message.Actions != null)
				{
					foreach (var action in message.Actions)
					{
						if (action.Type == "MEAppEvent" && action is AppEventActionModel appEventAction) {
							Console.WriteLine($"Action: {appEventAction.Id} - {appEventAction.Title} - {appEventAction.Type} - {appEventAction.Name}");
							if (appEventAction.Payload != null) {
								foreach (var item in appEventAction.Payload)
								{
									Console.WriteLine($"Payload item: {item.Key} - {item.Value}");
								}
							}
						} else if (action.Type == "OpenExternalUrl" && action is OpenExternalUrlActionModel openExternalUrlAction) {
							Console.WriteLine($"Action: {openExternalUrlAction.Id} - {openExternalUrlAction.Title} - {openExternalUrlAction.Type} - {openExternalUrlAction.Url}");
						}
					}
				} else {
					Console.WriteLine("No actions found.");
				}
			}
		}
	}
}
