namespace Sample;

using EmarsysBinding;
using EmarsysBinding.Model;

public partial class InAppPage : ContentPage
{

	EMSMessage? FetchedMessage;

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
		var results = await Emarsys.Inbox.FetchMessages();
		if (results.Error != null)
		{
			Utils.LogResult("FetchMessages", results.Error);
		}
		else
		{
			LogInboxMessages(results.Messages);
		}
	}

	private async void OnAddTagClicked(object sender, EventArgs e)
	{
		if (FetchedMessage != null)
		{
			var tag = "seen";
			var messageId = FetchedMessage.Id;
			var error = await Emarsys.Inbox.AddTag(tag, messageId);
			Utils.LogResult("AddTag", error);
		}
		else
		{
			Utils.DisplayAlert("Call Fetch Messages first!");
		}
	}

	private async void OnRemoveTagClicked(object sender, EventArgs e)
	{
		if (FetchedMessage != null)
		{
			var tag = "seen";
			var messageId = FetchedMessage.Id;
			var error = await Emarsys.Inbox.RemoveTag(tag, messageId);
			Utils.LogResult("RemoveTag");
		}
		else
		{
			Utils.DisplayAlert("Call Fetch Messages first!");
		}
	}

	private void LogInboxMessages(List<EMSMessage>? messages)
	{
		if (messages == null || messages.Count == 0)
		{
			Utils.LogResult("FetchMessages", null, "No messages found");
		}
		else
		{
			FetchedMessage = messages[0];
			Utils.LogResult("FetchMessages", null, $"{messages.Count} messages found");
			foreach (var message in messages)
			{
				Console.WriteLine("----------------------------------");
				Console.WriteLine($"Id: {message.Id}");
				Console.WriteLine($"CampaignId: {message.CampaignId}");
				Console.WriteLine($"CollapseId: {message.CollapseId}");
				Console.WriteLine($"Title: {message.Title}");
				Console.WriteLine($"Body: {message.Body}");
				Console.WriteLine($"ImageUrl: {message.ImageUrl}");
				Console.WriteLine($"ReceivedAt: {message.ReceivedAt}");
				Console.WriteLine($"UpdatedAt: {message.UpdatedAt}");
				Console.WriteLine($"ExpiresAt: {message.ExpiresAt}");

				if (message.Tags != null && message.Tags?.Count > 0)
				{
					Console.WriteLine("Tags:");
					foreach (var tag in message.Tags)
					{
						Console.WriteLine($"- {tag}");
					}
				} else {
					Console.WriteLine("No tags found");
				}

				if (message.Properties != null && message.Properties?.Count > 0)
				{
					Console.WriteLine("Properties:");
					foreach (var item in message.Properties)
					{
						Console.WriteLine($"- Key: {item.Key} - Value: {item.Value}");
					}
				} else {
						Console.WriteLine("No properties found");
				}

				if (message.Actions != null && message.Actions?.Count > 0)
				{
					Console.WriteLine("Actions:");
					foreach (var action in message.Actions)
					{
						if (action.Type == "MEAppEvent" && action is EMSAppEventActionModel appEventAction) {
							Console.WriteLine($"- ID: {appEventAction.Id}");
							Console.WriteLine($" - Title: {appEventAction.Title}");
							Console.WriteLine($" - Type: {appEventAction.Type}");
							Console.WriteLine($" - Name: {appEventAction.Name}");
							if (appEventAction.Payload != null && appEventAction.Payload?.Count > 0) {
								Console.WriteLine(" - Payload:");
								foreach (var item in appEventAction.Payload)
								{
									Console.WriteLine($" -- Key: {item.Key} - Value: {item.Value}");
								}
							}
						} else if (action.Type == "OpenExternalUrl" && action is EMSOpenExternalUrlActionModel openExternalUrlAction) {
							Console.WriteLine($"- ID: {openExternalUrlAction.Id}");
							Console.WriteLine($" - Title: {openExternalUrlAction.Title}");
							Console.WriteLine($" - Type: {openExternalUrlAction.Type}");
							Console.WriteLine($" - URL: {openExternalUrlAction.Url}");
						}
					}
				} else {
					Console.WriteLine("No actions found");
				}
			}
		}
	}

}
