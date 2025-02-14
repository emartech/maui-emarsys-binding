namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

class ActionModelMapper
{

	public static List<ActionModel> Map(object input)
	{
		if (input is List<object> inputList)
		{
			return inputList
				.Where(element => element is Dictionary<string, object> actionMap && actionMap.Count > 0)
				.Select(element =>
				{
					return MapAction((Dictionary<string, object>)element);
				})
				.Where(action => action != null)
				.Cast<ActionModel>()
				.ToList();
		}
		return new List<ActionModel>();
	}

	private static ActionModel? MapAction(Dictionary<string, object> actionMap)
	{
		if (!actionMap.ContainsKey("type") || actionMap["type"] == null)
		{
			Console.WriteLine("Action map does not contain a valid 'type'.");
			return null;
		}

		var type = (string)actionMap["type"];
		switch (type)
		{
			case "MEAppEvent":
				return new AppEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
					payload: actionMap.ContainsKey("payload")
						? (Dictionary<string, object>)actionMap["payload"]
						: null
				);

			case "MECustomEvent":
				return new CustomEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
					payload: actionMap.ContainsKey("payload")
						? (Dictionary<string, object>)actionMap["payload"]
						: null
				);

			case "OpenExternalUrl":
				return new OpenExternalUrlActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					url: (string)actionMap["url"]
				);

			default:
				return null;
		}
	}

}
