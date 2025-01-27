namespace EmarsysBinding.Model;

public class EMSActionModel
{

	public string Id { get; set; }
	public string Title { get; set; }
	public string Type { get; set; }

	public EMSActionModel(string id, string title, string type)
	{
		Id = id;
		Title = title;
		Type = type;
	}

}

public class EMSAppEventActionModel : EMSActionModel
{

	public string Name { get; set; }
	public Dictionary<string, object>? Payload { get; set; }

	public EMSAppEventActionModel(
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

public class EMSCustomEventActionModel : EMSActionModel
{

	public string Name { get; set; }
	public Dictionary<string, object>? Payload { get; set; }

	public EMSCustomEventActionModel(
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

public class EMSOpenExternalUrlActionModel : EMSActionModel
{

	public string Url { get; set; }

	public EMSOpenExternalUrlActionModel(
		string id,
		string title,
		string type,
		string url
	) : base(id, title, type)
	{
		Url = url;
	}

}
