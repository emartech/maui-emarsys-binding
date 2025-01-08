namespace EmarsysBinding.Model;

public class EMSMessage
{
	public string Id { get; set; }
	public string CampaignId { get; set; }
	public string? CollapseId { get; set; }
	public string Title { get; set; }
	public string Body { get; set; }
	public string? ImageUrl { get; set; }
	public int ReceivedAt { get; set; }
	public int? UpdatedAt { get; set; }
	public int? ExpiresAt { get; set; }
	public List<string>? Tags { get; set; }
	public Dictionary<string, object>? Properties { get; set; }
	public List<EMSActionModel>? Actions { get; set; }

	public EMSMessage(
		string id,
		string campaignId,
		string title,
		string body,
		int receivedAt,
		string? collapseId = null,
		string? imageUrl = null,
		int? updatedAt = null,
		int? expiresAt = null,
		List<string>? tags = null,
		Dictionary<string, object>? properties = null,
		List<EMSActionModel>? actions = null
	)
	{
		Id = id;
		CampaignId = campaignId;
		CollapseId = collapseId;
		Title = title;
		Body = body;
		ImageUrl = imageUrl;
		ReceivedAt = receivedAt;
		UpdatedAt = updatedAt;
		ExpiresAt = expiresAt;
		Tags = tags;
		Properties = properties;
		Actions = actions;
	}
}
