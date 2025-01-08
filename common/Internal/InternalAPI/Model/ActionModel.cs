namespace EmarsysBinding.Model;

using System;
using System.Collections.Generic;

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
	public Dictionary<string, string>? Payload { get; set; }

	public AppEventActionModel(
		string id,
		string title,
		string type,
		string name,
			Dictionary<string, string>? payload = null
	) : base(id, title, type)
	{
		Name = name;
		Payload = payload;
	}
}

public class CustomEventActionModel : ActionModel
{
	public string Name { get; set; }
	public Dictionary<string, string>? Payload { get; set; }

	public CustomEventActionModel(
		string id,
		string title,
		string type,
		string name,
		Dictionary<string, string>? payload = null
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