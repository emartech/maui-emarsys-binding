namespace EmarsysBinding.Internal;

using System;
using System.Collections.Generic;

public class Message
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
	public Dictionary<string, string>? Properties { get; set; }
	public List<ActionModel>? Actions { get; set; }

	public Message(
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
		Dictionary<string, string>? properties = null,
		List<ActionModel>? actions = null
	)
	{
		Id = id;
		CampaignId = campaignId;
		Title = title;
		Body = body;
		ReceivedAt = receivedAt;
		CollapseId = collapseId;
		ImageUrl = imageUrl;
		UpdatedAt = updatedAt;
		ExpiresAt = expiresAt;
		Tags = tags;
		Properties = properties;
		Actions = actions;
	}
}
