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

public class ActionModel
{
	public string Id { get; set; }
	public string Title { get; set; }
	public string Type { get; set; }

	public ActionModel(string id, string title, string type)
	{
		Id = id;
		Title = title;
		Type = type;
	}
}

public class AppEventActionModel : ActionModel
{
	public string Name { get; set; }
	public Dictionary<string, object>? Payload { get; set; }

	public AppEventActionModel(
		string id,
		string title,
		string type,
		string name,
			Dictionary<string, object>? payload = null
	) : base(id, title, type)
	{
		Name = name;
		Payload = payload;
	}
}

public class CustomEventActionModel : ActionModel
{
	public string Name { get; set; }
	public Dictionary<string, object>? Payload { get; set; }

	public CustomEventActionModel(
		string id,
		string title,
		string type,
		string name,
		Dictionary<string, object>? payload = null
	) : base(id, title, type)
	{
		Name = name;
		Payload = payload;
	}
}

public class OpenExternalUrlActionModel : ActionModel
{
	public string Url { get; set; }

	public OpenExternalUrlActionModel(
		string id,
		string title,
		string type,
		string url
	) : base(id, title, type)
	{
		Url = url;
	}
}